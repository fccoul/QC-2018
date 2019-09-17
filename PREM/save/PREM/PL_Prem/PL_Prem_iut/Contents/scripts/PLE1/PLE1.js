(function (window, $) {
    var fenetreModalChargement = $('#ModaleChargement');
    var numeroPratique;
    // ### Initialisation des evenements ###
    $(document).ready(function () {
        InactiverOnglets();
        $('#NumeroPratique').val('');
        ChangementIdentiteProfessionnel();
        InactiverPostToucheEnter();
        InitialiseDatepicker();
        ActiverBoutons();
        $('#NumeroPratique').focus();
    });

    // Activer les boutons
    function ActiverBoutons() {
        var myID;

        $('#confirm-delete').on('show.bs.modal', function (e) {
            var data = $(e.relatedTarget).data();
            $('.title', this).text("" + data.recordTitle);
            myID = data.recordId;
            $('.icone-rouge', this).data('recordId', data.recordId);
        });

        $('#confirm-delete').on('click', '.btn-ok', function (e) {
            var $modalDiv = $(e.delegateTarget);

            AnnulerDemandeReevaluation(myID);
            $modalDiv.addClass('loading');
            setTimeout(function () {
                $modalDiv.modal('hide').removeClass('loading');
                $("#" + myID).animate({ opacity: 0.0 }, 400, function () {
                    $("#" + myID).remove();
                    var rowCount = $('#tableReevaluations tbody tr').length;
                    $('#sectionTableau center').html('');
                    if (rowCount === 0) {
                        $('#tableReevaluations').closest("div").append("<center><i>Aucune demande de réévaluation</i></center>");
                    } else if (rowCount > 1) {
                        $('#sectionTableau h4').html("Périodes de réévaluation prévues");
                    }
                    else {
                        $('#sectionTableau h4').html("Période de réévaluation prévue");
                    }
                });
            }, 400);
        });

        
            $("#btnTransmettre").prop("disabled", false);
            $('.btn-ok').prop("disabled", false);
            $("#btnTransmettre").click(function () {
                if ($('form').valid())
                    CreerDemandesReeva();
            });
        
    }

    //Nettoyer les messages d'erreur
    function ClearValidation() {
        var validator = $('form').validate();
        $('form').find('.field-validation-error span').each(function () {
            validator.settings.success($(this));
        });
        validator.resetForm();
    }

    // Initialisation des date pickes
    function InitialiseDatepicker() {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            language: 'fr',
            orientation: "bottom auto"
        });
    }

    // Permet d'afficher la fenêtre de chargement
    function AfficherFenetreChargement() {
        fenetreModalChargement.modal('show');
    }

    // Permet de cacher la fenêtre de chargement
    function CacherFenetreChargement() {
        fenetreModalChargement.modal('hide');
    }

    // Permet d'empêcher la "POST" de la page lors qu'on appuis sur "ENTER"
    function InactiverPostToucheEnter() {
        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
                $('#boutonRechercherProfessionnel').click();
            }
        });
    }

    // Chargement de l'identité du professionnel
    function ChangementIdentiteProfessionnel() {
        $('#boutonRechercherProfessionnel').click(function () {
            AfficherFenetreChargement();

            // Permet d'enlever le focus du textbox comme si l'usager aurait cliquer sur le bouton
            // et force la validation du champs
            $('#boutonRechercherProfessionnel').focus();

            if ($("#NumeroPratique").val().length === 6 && $("#NumeroPratique").val().charAt(0) === '1') {
                InactiverOnglets();
                ObtenirInformationMedecin($("#NumeroPratique").val(), true);
                ClearValidation();
                $('#DateDebut').val('');
                $('#DateFin').val('');
            }
            else {
                $('#NumeroPratique').valid();
                CacherFenetreChargement();
            }
        });
    }

    // Annuler une demande de réévaluation
    function AnnulerDemandeReevaluation(numeroDemande) {
        $.ajax({
            type: 'POST',
            url: controlleurPLE1.AnnulerDemande,
            data: { noSeqDemande: numeroDemande },
            success: function (obj) { },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript AnnulerDemandeReevaluation');
            }
        });
    }

    // Obtient les informations du médecin sélectionné
    function ObtenirInformationMedecin(numeroPratique, nouveauDisp) {
        if (numeroPratique.length > 0) {
            $.ajax({
                type: 'POST',
                url: controlleurPLE1.ObtenirInformationMedecin,
                data: { numeroProfessionnel: numeroPratique },
                success: function (obj) {
                    InactiverOnglets();
                    if (nouveauDisp) {
                        $('#MessageInformation').html('').css('display', 'none');
                    }
                    $('#informationMedecin').empty();
                    if (obj.MessageErreurs.length === 0 && obj.NumeroSequentielDispensateur > 0) {
                        CacherFenetreChargement();
                        if (obj.DateObtentionPermis !== null) {
                            $('#informationMedecin').append(
                                '<p>Permis obtenu le ' + FormaterDateLong(FormatterDate(FormatterJsonDate(obj.DateObtentionPermis))) + '</p>');
                        }
                        ConstruireTableauReevaluation(obj.DemandesReevaluation);
                        ReactiverOnglets();
                        $('#NomPrenomProfessionnel').text(obj.NomAffichage);
                    }
                    else {
                        $('#NomPrenomProfessionnel').text('');
                        InactiverOnglets();
                        CacherFenetreChargement();
                        var textErreur = '';
                        for (var i = 0; i < obj.MessageErreurs.length; i++) {
                            textErreur = textErreur + obj.MessageErreurs[i] + '<br/>';
                        }
                        if (textErreur !== '') {
                            $('#MessageInformation').html(textErreur).css('display', 'block').removeClass('hidden');
                        }
                    }
                },
                error: function (err) {
                    ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationMedecin');
                }
            });
        }
    }

    // Permet de faire la construction du tableau des réévaluations
    function ConstruireTableauReevaluation(DemandesReevaluation) {
        var contenuTableau = "";

        for (var i = 0; i < DemandesReevaluation.length; i++) {
            var dateDebut = FormaterDateLong(FormatterDate(FormatterJsonDate(DemandesReevaluation[i].DateDebutReeva)));
            var dateFin = FormaterDateLong(FormatterDate(FormatterJsonDate(DemandesReevaluation[i].DateFinReeva)));

            contenuTableau += "<tr id=" + DemandesReevaluation[i].NumeroSequentielDemande + "><td>"
                + FormatterDate(FormatterJsonDate(DemandesReevaluation[i].DateDebutReeva)) + "</td><td>"
                + FormatterDate(FormatterJsonDate(DemandesReevaluation[i].DateFinReeva)) + "</td><td>"
                + (DemandesReevaluation[i].CategorieDemande === 1 ? "Complète" : "Partielle") + "</td><td>";

            if (DemandesReevaluation[i].CodeSourceDemande === 1) {
                contenuTableau += DemandesReevaluation[i].IdentifiantCreation + '</td>';
                
                contenuTableau += '<td><a href="#" data-record-id="' + DemandesReevaluation[i].NumeroSequentielDemande
                                + '" data-record-title="' + DemandesReevaluation[i].NumeroSequentielDispensateur + ' pour la période du '
                                + dateDebut + ' au ' + dateFin + '" data-toggle="modal" data-target="#confirm-delete">'
                                + '<i class="icone-rouge fa fa-trash " aria-hidden="false"></i></a></td>';
                
            } else {
                contenuTableau += 'Système</td>';
            }
            contenuTableau += "</tr>";
        }

        $('#sectionTableau center').html('');
        $('#tableReevaluations tbody').html(contenuTableau);
        if (DemandesReevaluation.length === 0) {
            $('#tableReevaluations').closest("div").append("<center><i>Aucune demande de réévaluation</i></center>");
        } else if (DemandesReevaluation.length > 1) {
            $('#sectionTableau h4').html("Périodes de réévaluation prévues");
        }
    }

    // Créer une demande de réévaluation
    function CreerDemandesReeva() {
        var typeReeva = $("#TypeDemande").children("option").filter(":selected").val();
        AfficherFenetreChargement();
        $.ajax({
            type: 'POST',
            url: controlleurPLE1.CreerDemandeReevaluation,
            data: {
                DateDebut: new Date($("#DateDebut").val()).toISOString(),
                DateFin: new Date($("#DateFin").val()).toISOString(),
                categorie: typeReeva
            },
            success: function (obj) {
                CacherFenetreChargement();
                $('#MessageInformation').html('');
                $('#MessageInformation').css('display', 'none');

                var numeroPratique = $("#NumeroPratique").val();
                ObtenirInformationMedecin(numeroPratique, false);

                if (obj.InfoMsgTrait.length !== 0) {
                    for (var i = 0; i < obj.InfoMsgTrait.length; i++) {
                        $('#MessageInformation').append(obj.InfoMsgTrait[i].TxtMsgFran + '<br/>');
                    }
                    $('#MessageInformation').css('display', 'block').removeClass('hidden');
                }
                
                
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript CreerDemandesReeva");
            }
        });
    }

    // Permet d'inactiver onglets
    function InactiverOnglets() {
        $('#sectionSaisie').attr('hidden', 'true');
        $('#sectionSaisie').innerHTML = '';
        $('#sectionTableau').attr('hidden', 'true');
        $('#sectionTableau').innerHTML = '';
    }

    // Permet de réactiver les onglets
    function ReactiverOnglets() {
        $('#sectionSaisie').removeAttr('hidden');
        $('#sectionTableau').removeAttr('hidden').css({ opacity: 0.0 });
        $("#sectionTableau").animate({ opacity: 1.0 }, 400, function () { });
    }

    // Permet de formater la date sous le format long
    function FormaterDateLong(date) {
        var dateFormater = '';
        $.ajax({
            cache: false,
            type: 'POST',
            url: controlleurCommun.FormaterDateLong,
            data: { date: date },
            async: false,
            success: function (obj) {
                dateFormater = obj;
            },
            error: function (err) {
                ErreurTechnique(err, 'Erreur pendant un appel AJAX dans la fonction javascript FormaterDateLong');
            }
        });
        return dateFormater;
    }

    // ### Interfaces ###
    if ('undefined' === typeof window.RAMQ)
        window.RAMQ = new Object();

    if ('undefined' === typeof window.RAMQ.Web)
        window.RAMQ.Web = new Object();

    if ('undefined' === typeof window.RAMQ.Web.PLE1)
        window.RAMQ.Web.PLE1 = {
            'AfficherFenetreChargement': AfficherFenetreChargement,
            'CacherFenetreChargement': CacherFenetreChargement
        };
})(window, $);

$(window).load(function () {
    $('.main').show();
    $('#NumeroPratique').focus();
});