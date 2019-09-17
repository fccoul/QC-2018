(function (window, $) {

    window.optionsDataTable = {
        language: {
            processing: "Traitement en cours...",
            search: "Rechercher&nbsp;:",
            lengthMenu: "Afficher _MENU_ &eacute;l&eacute;ments",
            info: "Affichage de l'&eacute;lement _START_ &agrave; _END_ sur _TOTAL_ &eacute;l&eacute;ments",
            infoEmpty: "Affichage de l'&eacute;lement 0 &agrave; 0 sur 0 &eacute;l&eacute;ments",
            infoFiltered: "(filtr&eacute; de _MAX_ &eacute;l&eacute;ments au total)",
            infoPostFix: "",
            loadingRecords: "Chargement en cours...",
            zeroRecords: "Aucun &eacute;l&eacute;ment &agrave; afficher",
            emptyTable: "Aucune donnée disponible dans le tableau",
            paginate: {
                first: "Premier",
                previous: "Pr&eacute;c&eacute;dent",
                next: "Suivant",
                last: "Dernier"
            },
            aria: {
                sortAscending: ": activer pour trier la colonne par ordre croissant",
                sortDescending: ": activer pour trier la colonne par ordre décroissant"
            }
        },
        scrollX: false,
        retrieve: true
    };

    // ### Initialisation des evenements ###
    $(document).ready(function () {

        //
        // Pipelining function for DataTables. To be used to the `ajax` option of DataTables
        //
        $.fn.dataTable.pipeline = function (opts) {
            // Configuration options
            var conf = $.extend({
                pages: 5,     // number of pages to cache
                url: '',      // script url
                data: null,   // function or object with parameters to send to the server
                // matching how `ajax.data` works in DataTables
                method: 'POST' // Ajax HTTP method
            }, opts);

            // Private variables for storing the cache
            var cacheLower = -1;
            var cacheUpper = null;
            var cacheLastRequest = null;
            var cacheLastJson = null;

            return function (request, drawCallback, settings) {
                var ajax = false;
                var requestStart = request.start;
                var drawStart = request.start;
                var requestLength = request.length;
                var requestEnd = requestStart + requestLength;

                if (settings.clearCache) {
                    // API requested that the cache be cleared
                    ajax = true;
                    settings.clearCache = false;
                }
                else if (cacheLower < 0 || requestStart < cacheLower || requestEnd > cacheUpper) {
                    // outside cached data - need to make a request
                    ajax = true;
                }
                else if (JSON.stringify(request.order) !== JSON.stringify(cacheLastRequest.order) ||
                          JSON.stringify(request.columns) !== JSON.stringify(cacheLastRequest.columns) ||
                          JSON.stringify(request.search) !== JSON.stringify(cacheLastRequest.search)
                ) {
                    // properties changed (ordering, columns, searching)
                    ajax = true;
                }

                // Store the request for checking next time around
                cacheLastRequest = $.extend(true, {}, request);

                if (ajax) {
                    // Need data from the server
                    if (requestStart < cacheLower) {
                        requestStart = requestStart - (requestLength * (conf.pages - 1));

                        if (requestStart < 0) {
                            requestStart = 0;
                        }
                    }

                    cacheLower = requestStart;
                    cacheUpper = requestStart + (requestLength * conf.pages);

                    request.start = requestStart;
                    request.length = requestLength * conf.pages;

                    // Provide the same `data` options as DataTables.
                    if ($.isFunction(conf.data)) {
                        // As a function it is executed with the data object as an arg
                        // for manipulation. If an object is returned, it is used as the
                        // data object to submit
                        var d = conf.data(request);
                        if (d) {
                            $.extend(request, d);
                        }
                    }
                    else if ($.isPlainObject(conf.data)) {
                        // As an object, the data given extends the default
                        $.extend(request, conf.data);
                    }

                    settings.jqXHR = $.ajax({
                        "type": conf.method,
                        "url": conf.url,
                        "data": request,
                        "dataType": "json",
                        "cache": false,
                        "success": function (json) {
                            cacheLastJson = $.extend(true, {}, json);

                            if (cacheLower != drawStart) {
                                json.data.splice(0, drawStart - cacheLower);
                            }
                            if (requestLength >= -1) {
                                json.data.splice(requestLength, json.data.length);
                            }

                            drawCallback(json);
                        }
                    });
                }
                else {
                    json = $.extend(true, {}, cacheLastJson);
                    json.draw = request.draw; // Update the echo for each response
                    json.data.splice(0, requestStart - cacheLower);
                    json.data.splice(requestLength, json.data.length);

                    drawCallback(json);
                }
            }
        };

        // Register an API method that will empty the pipelined data, forcing an Ajax
        // fetch on the next draw (i.e. `table.clearPipeline().draw()`)
        $.fn.dataTable.Api.register('clearPipeline()', function () {
            return this.iterator('table', function (settings) {
                settings.clearCache = true;
            });
        });

        InitialiserChampsRecherche();
        InitialiserChampsTerritoires();
        InitialiserChampsDerogation();
        InitialiserTableaux();
    })

    // ### Fonctions privées ###
    var query = {};

    // Fonction utilisé pour ajouter un souligné pour la recherche de select2 4.0 
    // vu que la fonctionnalité ne s'y trouve plus, mais était dans le 3.5.2 (Code prit tel quel: https://github.com/select2/select2/issues/3153)
    function markMatch(text, term) {

        // Find where the match is
        var match = text.toUpperCase().indexOf(term.toUpperCase());

        var $result = $('<span></span>');

        // If there is no match, move on
        if (match < 0) {
            return $result.text(text);
        }

        // Put in whatever text is before the match
        $result.text(text.substring(0, match));

        // Mark the match
        var $match = $('<span class="select2-rendered__match"></span>');
        $match.text(text.substring(match, match + term.length));

        // Append the matching text
        $result.append($match);

        // Put in whatever is after the match
        $result.append(text.substring(match + term.length));

        return $result;
    }

    function InitialiserChampsRecherche() {
        var pageLimit = 10;
        var valeurInitial = "";
        var textInit = "";

        $(".select2recherche").select2({
            language: "fr",
            placeholder: "Numéro de pratique",
            allowClear: true,
            templateResult: function (item) {
                // No need to template the searching text
                if (item.loading) {
                    return item.text;
                }
                var term = query.term || '';
                var $result = markMatch(item.text, term);

                return $result;
            },
            ajax: {
                dataType: "json",
                type: "POST",
                url: controlleurCommun.ObtenirNumerosPratique,
                delay: 500,
                contentType: "application/json",
                data: function (params) {
                        return JSON.stringify({
                            intrant: {
                                Terme: params.term,
                                LimiteParPage: pageLimit,
                                ClassesProfessionnelUtilise: $(".select2recherche").attr("classesProfessionnelUtilise").split(',').map(Number),
                                Page: params.page,
                                FiltreSpecialPourCreationAvis: $(".select2recherche").attr("filtreSpecialPourCreationAvis")
                            }
                        });
                    },
                processResults: function (data, params) {
                    query = params;
                    params.page = params.page || 1;
                    return {
                        results: $.map(data.ListeResultat, function (obj) {
                            return { id: obj.Key, text: obj.Value };
                        }),
                        pagination: {
                            more: (params.page * pageLimit) < data.TotalResultat
                        }
                    };
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript InitialiserChampsRecherche");
                },
                cache: true
            },
            escapeMarkup: function (markup) { return markup; },
            minimumInputLength: 1,
        }).on("select2:select", function (e) {
            var selected = e.params.data;
            if (typeof selected !== "undefined") {
                $("[name='IdDDL']").val(selected.id);
                $("[name='TextDDL']").val(selected.text);
            }
        }).on("select2:unselecting", function (e) {
            $("[name='IdDDL']").val("");
            $("[name='TextDDL']").val("");
        });

        valeurInitial = $("[name='IdDDL']").val();
        textInit = $("[name='TextDDL']").val();

        if (valeurInitial != "") {
            var $option = $('<option selected>' + textInit + '</option>').val(valeurInitial);
            $(".select2recherche").append($option).trigger('change');
        }
    }

    function InitialiserChampsTerritoires() {
        $(".select2dropdownlist").select2({
            language: "fr",
            placeholder: "Sélectionnez le territoire",
            allowClear: true,
            minimumResultsForSearch: "Infinity"
        });
    }

    function InitialiserChampsDerogation() {
        $(".select2derogation").select2({
            language: "fr",
            placeholder: "Sélectionnez un type de dérogation",
            allowClear: true,
            minimumResultsForSearch: "Infinity"
        });
    }

    function InitialiserTableaux() {
        window.optionsDataTable = {
            language: {
                processing: "Traitement en cours...",
                search: "Rechercher&nbsp;:",
                lengthMenu: "Afficher _MENU_ &eacute;l&eacute;ments",
                info: "Affichage de l'&eacute;lement _START_ &agrave; _END_ sur _TOTAL_ &eacute;l&eacute;ments",
                infoEmpty: "Affichage de l'&eacute;lement 0 &agrave; 0 sur 0 &eacute;l&eacute;ments",
                infoFiltered: "(filtr&eacute; de _MAX_ &eacute;l&eacute;ments au total)",
                infoPostFix: "",
                loadingRecords: "Chargement en cours...",
                zeroRecords: "Aucun &eacute;l&eacute;ment &agrave; afficher",
                emptyTable: "Aucune donnée disponible dans le tableau",
                paginate: {
                    first: "Premier",
                    previous: "Pr&eacute;c&eacute;dent",
                    next: "Suivant",
                    last: "Dernier"
                },
                aria: {
                    sortAscending: ": activer pour trier la colonne par ordre croissant",
                    sortDescending: ": activer pour trier la colonne par ordre décroissant"
                }
            },
            scrollX: false,
            retrieve: true
        };
        $(".dataTable").DataTable(window.optionsDataTable);
    }



})(window, $);