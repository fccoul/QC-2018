(function (window, $) {

    $(document).ready(function () {
        
        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                $("#boutonRechercherProfessionnel").click();
            }
        });

        $("#NumeroPratique").focus();

        var enQuestion = false;
        var valider = $('#Valider').val();

        if (valider == "True") {
            enQuestion = true;
            ConfirmationAvis();
            $('#Valider').val("False");
            $('#ButtonOui').click(function () {
                Retransmettre();
            });
        }

        AfficherNomPrenomProfessionnel($("#TextDDL").val());

        ChangementValeurChamps(enQuestion);

    })

    function ConfirmationAvis() {
        $('#ConfirmationModal').modal({ show: true });
        return false;
    }

    function Retransmettre() {
        $('#Continuer').val("True");
    }

    function ChangementValeurChamps(enQuestion) {
        var numeroSequentiel = ObtenirNumeroSequentiel();
        var numeroPratique = ObtenirNumeroPratique();
        
        ValidationAvisActif(numeroSequentiel, enQuestion);

        ActiveDesactiveDate(numeroSequentiel, true);
        ActiveDesactiveTerritoire();
        ActiveDesactiveBoutonEtCaseCoche(numeroPratique);

        $("#boutonRechercherProfessionnel").click(function (event) {

            numeroPratique = ObtenirNumeroPratique();

            if (numeroPratique != null) {
                if (numeroPratique.length == 6 &&
                    (numeroPratique.charAt(0) == "1" ||
                     numeroPratique.charAt(0) == "5")) {

                    $(".alert-danger").html("");
                    ObtenirInformationProfessionnel(numeroPratique);

                    numeroSequentiel = ObtenirNumeroSequentiel();

                    if (numeroSequentiel != null) {
                        CacherDesactiverBoutonSupprimer();
                        ActiveDesactiveDate(numeroSequentiel, false);

                        if (numeroSequentiel != "") {
                            ValidationAvisActif(numeroSequentiel);
                        }

                        $(".alert-danger").prop('hidden', true);
                    }
                }
            }
        });

        $("#DatePrevue").change(function () {
            DateOnChange();
        });

        $("#Territoire").change(function () {
            numeroPratique = ObtenirNumeroPratique();
            ActiveDesactiveBoutonEtCaseCoche(numeroPratique);
        });
    }

    function ObtenirInformationProfessionnel(numeroPratique) {
        if (numeroPratique.length == 6) {
            ViderAlertMessage();
            $.ajax({
                type: 'POST',
                url: controlleurCommun.ObtenirProfessionnelRecherche,
                async: false,
                data: {
                    NumeroPratique: numeroPratique,
                    ClassesPossible: [1, 5]
                },
                success: function (obj) {
                    if (obj.MessageErreurs.length == 0) {
                        CacherZoneAlertMessage();
                        var professionnelEnErreur = false;
                        var numeroMessageErreur = "";

                        if (obj.NumeroSequentielIndividu != null) {
                            var numeroClasse = numeroPratique.charAt(0);
                            if (numeroClasse == "5") {
                                professionnelEnErreur = ValideSiClasseUn(obj.NumeroSequentielIndividu);
                                if (professionnelEnErreur) {
                                    numeroMessageErreur = "149243";
                                }
                            }
                        }                        

                        if (professionnelEnErreur) {
                            AfficherAlertMessage(RetourneMessageErreur(numeroMessageErreur));
                            AfficherZoneAlertMessage();
                            ViderInformationProfessionnel();
                        }
                        else {
                            AfficherNomPrenomProfessionnel(obj.NomAffichage);
                            $("#TextDDL").val(obj.NomAffichage);
                            $("#IdDDL").val(obj.NumeroSequentielDispensateur);
                        }
                    }
                    else {
                        var textErreur = "";
                        for (var i = 0; i < obj.MessageErreurs.length; i++) {
                            textErreur = textErreur + obj.MessageErreurs[i] + SautDeLigne(1);
                        }
                        AfficherAlertMessage(textErreur);
                        AfficherZoneAlertMessage();
                        ViderInformationProfessionnel();
                    }
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationProfessionnel");
                }
            });
        }
    }

    function ValideSiClasseUn(numeroIndividu) {
        var possedeClasseUn = false;
        $.ajax({
            type: 'POST',
            url: controlleurCommun.ProfessionnelPossedeClasseUn,
            async: false,
            data: {
                NumeroIndividu: numeroIndividu,
                Classe: 1
            },
            success: function (retour) {
                possedeClasseUn = (retour == "True") ? true : false;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationProfessionnel");
            }
        });
        return possedeClasseUn;
    }

    function ValidationAvisActif(numero, enQuestion) {
        enQuestion = enQuestion || false;
        ViderAlertMessage();

        if (numero.length > 0) {
            var guid = $("#Guid").val();
            $.ajax({
                cache: false,
                type: 'POST',
                url: controlleurPLA1.ValidationAvisEnCours,
                contentType: "application/json",
                data: JSON.stringify({
                    intrant: {
                        NumeroPratique: numero,
                        VerifierAvisEnAttente: true
                    },
                    guid: guid
                }),
                async: false,
                success: function (obj) {
                    AfficherAlertMessage(obj.MessageAvertissement);
                    AfficherZoneAlertMessage();

                    var estEnErreur = $('.validation-summary-errors');
                    if (estEnErreur.length == 0) {

                        var redirection = $("#InfoRedirection").val();
                        if (redirection != "True" && !enQuestion) {
                            if (obj.AvisEnregistrer) {
                                var dateFormatter = FormatterDate(FormatterJsonDate(obj.DateDebutPratique));
                                $(".datepicker").datepicker("update", dateFormatter);
                                $("#DatePrevue").val(dateFormatter).trigger('change');
                                $("[name='IdTerritoireDDL']").val(obj.TerritoireId);
                                $("[name='TextTerritoireDDL']").val(obj.TerritoireNom);
                                var $option = $('<option selected>' + obj.TerritoireNom + '</option>').val(obj.TerritoireId);
                                $("#Territoire").append($option).trigger('change');

                                ActiverBoutonSupprimer();
                            } else {
                                CacherDesactiverBoutonSupprimer();
                            }
                        } else {
                            $("#InfoRedirection").val(false);
                            if (obj.AvisEnregistrer) {
                                ActiverBoutonSupprimer();
                            }
                        }
                    }
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript ValidationAvisActif");
                }
            });

        } else {
            CacherZoneAlertMessage();
        }
    }

    function CacherDesactiverBoutonSupprimer() {
        $("#SupprimerAvis").prop("hidden", true);
        $("#SupprimerAvis").prop("disabled", true);
    }

    function ActiverBoutonSupprimer() {
        $("#SupprimerAvis").prop("hidden", false);
        if (!ValiderGroupeSupport()) {
            $("#SupprimerAvis").prop("disabled", false);
        }
    }

    function DateOnChange() {
        var numeroPratique = ObtenirNumeroPratique();

        ActiveDesactiveTerritoire();
        ActiveDesactiveBoutonEtCaseCoche(numeroPratique);
    }

    //Pour que l'event du change se fasse lorsque la date est entrée manuellement...
    function InitialiseDatepicker() {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            language: 'fr',
            orientation: "bottom auto"
        }).on('changeDate', function (e) {
            DateOnChange();
        });
    }

    function ActiveDesactiveDate(numeroProfessionnel, pageLoad) {
        if (numeroProfessionnel.length > 0) {
            $("#DatePrevue").prop('disabled', false);
            if (!pageLoad) {
                $("#DatePrevue").val("").trigger('change');
            }
            $(".datepicker").datepicker('remove');
            InitialiseDatepicker();
        } else {
            $("#DatePrevue").prop('disabled', true);
            $("#DatePrevue").val("").trigger('change');
            $(".datepicker").datepicker('remove');
        }
    }

    function ActiveDesactiveTerritoire() {
        var datePrevue = $("#DatePrevue").val();
        if (datePrevue != "") {
            if (EstDateValide(datePrevue)) {
                var territoire = $("#Territoire").select2("val");

                if (territoire != "") {
                    var territoires = {};
                    $.ajax({
                        cache: false,
                        type: 'POST',
                        url: controlleurPLA1.ObtenirTerritoiresPermis,
                        data: {
                            dateDebutPratique: datePrevue
                        },
                        async: false,
                        success: function (liste) {
                            territoires = liste;
                        },
                        error: function (err) {
                            ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript ActiveDesactiveTerritoire");
                        }
                    });

                    var garderValeurTerritoire = false;

                    $.each(territoires, function (index, value) {
                        if (territoire == value.Id) {
                            garderValeurTerritoire = true;
                        }
                    });

                    if (!garderValeurTerritoire) {
                        EnleverOptionTerritoire();
                    }

                    $("#Territoire").prop('disabled', false);
                    InitialiserTerritoires(datePrevue);
                } else {
                    $("#Territoire").prop('disabled', false);
                    InitialiserTerritoires(datePrevue);
                }
            }
        } else {
            EnleverOptionTerritoire();
            $("#Territoire").prop('disabled', true);
            $("#Territoire").select2("val", "");
        }
    }

    function EnleverOptionTerritoire() {
        var valeurInitial = $("[name='IdTerritoireDDL']").val();
        if (valeurInitial != "") {
            $("[name='IdTerritoireDDL']").val("");
            $("[name='TextTerritoireDDL']").val("");
            $("#Territoire option[value='" + valeurInitial + "']").remove();
        }
    }

    function ActiveDesactiveBoutonEtCaseCoche(numeroPratique) {
        var numeroClasse = numeroPratique.charAt(0);
        var territoire = $("#Territoire").val();

        if (territoire != "" && !ValiderGroupeSupport()) {
            $("#TransmettreAvis").prop('disabled', false);
            $("#Confirmation").prop('disabled', false);
            $("#EnregistrerAvis").prop('disabled', false);

            if (numeroClasse == "5") {
                $("#TransmettreAvis").prop('disabled', true);
                $("#Confirmation").prop('disabled', true);
            }
        } else {
            $("#TransmettreAvis").prop('disabled', true);
            $("#Confirmation").prop('disabled', true);
            $("#EnregistrerAvis").prop('disabled', true);
        }
    }

    function InitialiserTerritoires(datePrevue) {
        $("#Territoire").select2({
            language: "fr",
            placeholder: "Sélectionnez le territoire",
            allowClear: true,
            minimumResultsForSearch: "Infinity",
            ajax: {
                cache: false,
                dataType: "json",
                type: "POST",
                url: controlleurPLA1.ObtenirTerritoiresPermis,
                data: {
                    dateDebutPratique: datePrevue
                },
                processResults: function (data) {
                    return {
                        results: $.map(data, function (obj) {
                            return {
                                id: obj.Id, text: obj.Nom
                            };
                        })
                    };
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript InitialiserTerritoires");
                }
            }
        }).on("select2:select", function (e) {
            var selected = e.params.data;
            if (typeof selected !== "undefined") {
                $("[name='IdTerritoireDDL']").val(selected.id);
                $("[name='TextTerritoireDDL']").val(selected.text);
            }
        }).on("select2:unselecting", function (e) {
            $("[name='IdTerritoireDDL']").val("");
            $("[name='TextTerritoireDDL']").val("");
        });

        var valeurInitial = $("[name='IdTerritoireDDL']").val();
        var textInit = $("[name='TextTerritoireDDL']").val();

        if (valeurInitial != "") {
            var $option = $('<option selected>' + textInit + '</option>').val(valeurInitial);
            $("#Territoire").append($option).trigger('change');
        }
    }

    function ObtenirNumeroPratique() {
        return $("#NumeroPratique").val();
    }

    function ObtenirNumeroSequentiel() {
        return $("#IdDDL").val();
    }

    function AfficherAlertMessage(message) {
        $("#AlertAvis").html(message);
    }

    function ViderAlertMessage() {
        $("#AlertAvis").html("");
    }

    function AfficherZoneAlertMessage() {
        $("#AlertAvis").css("display", "block");
    }

    function CacherZoneAlertMessage() {
        $("#AlertAvis").css("display", "none");
    }

    function ViderInformationProfessionnel() {
        $("#NomPrenomProfessionnel").text("");
        $("#TextDDL").val("");
        $("#IdDDL").val("");
    }

    function AfficherNomPrenomProfessionnel(texte) {
        $("#NomPrenomProfessionnel").text(texte);
    }

})(window, $);