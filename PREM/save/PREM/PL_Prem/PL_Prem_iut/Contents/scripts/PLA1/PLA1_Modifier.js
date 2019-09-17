(function (window, $) {

    $(document).ready(function () {

        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                $("#boutonRechercherProfessionnel").click();
            }
        });

        $("#NumeroPratique").focus();

        AfficherNomPrenomProfessionnel($("#TextDDL").val());
        if ($("#NomPrenomProfessionnel").text() == "") {
            $("input[name=Decision]").prop("disabled", true);
        }

        if ($('input[name=Decision]:checked').val() != null) {
            $("#btnTransmettre").prop("disabled", false);
            $("#Confirmation").prop('disabled', false);
        }

        var valider = $('#Valider').val();

        if (valider == "True") {
            ConfirmationAvis();
            $('#Valider').val("False");
            $('#ButtonOui').click(function () {
                Retransmettre();
            });
        }

        AfficheValeur();
        ChangementValeurChamps();
        ValidationActiveChampDate();

    })

    function ConfirmationAvis() {
        $('#ConfirmationModal').modal({ show: true });
        return false;
    }

    function Retransmettre() {
        $('#Continuer').val("True");
    }

    function ValidationActiveChampDate() {

        if ($('.datepicker input').attr('disabled') == 'disabled') {
            $(".datepicker").datepicker('remove');
        }

        ActiveDesactiveChampDate();
    }

    function ActiveDesactiveChampDate() {
        if ($('input[name=Decision]:checked').val() == etatAvis.Reporter) {
            $(".datepicker").datepicker({
                format: 'yyyy-mm-dd',
                autoclose: true,
                language: 'fr'
            });
            $(".datepicker input").prop('disabled', false);
        }
        else {
            $(".datepicker").datepicker('remove');
            $(".datepicker input").prop('disabled', true);
            $('#DatePrevue').val("");
        }
    }

    function ChangementValeurChamps() {

        $("#boutonRechercherProfessionnel").click(function (event) {
            numeroPratique = ObtenirNumeroPratique();

            if (numeroPratique != null) {
                if (numeroPratique.length == 6) {
                    ObtenirInformationProfessionnel(numeroPratique);

                    numeroSequentiel = ObtenirNumeroSequentiel();

                    if (numeroSequentiel != null) {
                        if (numeroSequentiel != "") {
                            ObtenirInformationAvis(numeroSequentiel);
                            $(".alert-danger").prop('hidden', true);
                        }
                        else {
                            InitialiserChamps();
                            DesactiveChampsEtBouton();
                        }
                    }
                }
            }
        });

        $('input[name=Decision]').change(function () {
            ActiveDesactiveChampDate();
            $("#Confirmation").prop('disabled', false);
            if (!ValiderGroupeSupport()) {
                $("#btnTransmettre").prop("disabled", false);
            }
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
                    ClassesPossible: [1]
                },
                success: function (obj) {
                    if (obj.MessageErreurs.length == 0) {
                        CacherZoneAlertMessage();

                        AfficherNomPrenomProfessionnel(obj.NomAffichage);
                        $("#TextDDL").val(obj.NomAffichage);
                        $("#IdDDL").val(obj.NumeroSequentielDispensateur);
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

    function ObtenirInformationAvis(numero) {
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
                        VerifierAvisEnAttente: false
                    },
                    guid: guid
                }),
                async: false,
                success: function (obj) {
                    AfficherAlertMessage(obj.MessageAvertissement);
                    AfficherZoneAlertMessage();
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript ValidationAvisActif");
                }
            });

            $.ajax({
                cache: false,
                type: 'POST',
                url: controlleurPLA1.ObtenirAvisAModifier,
                data: {
                    numeroProfessionnel: numero,
                    guid: guid
                },
                async: false,
                success: function (obj) {
                    if (obj != "") {
                        var informationTerritoire = {
                            NumeroSequentiel: obj.NumeroSequentielRegroupement,
                            Type: obj.TypeLieuGeographique,
                            Code: obj.CodeLieuGeographique,
                            DateDebutPratique: FormatterJsonDate(obj.DateDebutEngagement)
                        };

                        var nomTerritoire = ObtenirNomTerritoire(informationTerritoire);
                        var dateDebut = FormatterDate(FormatterJsonDate(obj.DateDebutEngagement));

                        $("[name='Territoire']").val(nomTerritoire);
                        $("[name='IdTerritoireDDL']").val(GenereIDTerritoire(informationTerritoire));
                        $("#NomTerritoire").empty().append(nomTerritoire + SautDeLigne(2));

                        $("[name='DateDebut']").val(dateDebut);
                        $("#DateAvis").empty().append(dateDebut + SautDeLigne(2));

                        $("input[name=Decision]").removeAttr("disabled");

                        if (obj.Statut == "SUS") {
                            $("input[value=" + etatAvis.Reporter + "]").prop("disabled", true);
                        }
                        else {
                            $("input[value=" + etatAvis.Reporter + "]").removeAttr("disabled");
                        }

                        if (obj.MessageAvertissement != "") {
                            DesactiveChampsEtBouton();
                            AfficherAlertMessage($("#AlertAvis").html() + SautDeLigne(1) + obj.MessageAvertissement);
                        }
                    } else {
                        InitialiserChamps();
                        DesactiveChampsEtBouton();
                    }
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript ObtenirInformationAvis");
                }
            });
        } else {
            InitialiserChamps();
            DesactiveChampsEtBouton();
            CacherZoneAlertMessage();
        }
    }

    function DesactiveChampsEtBouton() {
        $("input[name=Decision]").prop("disabled", true);
        $("#Confirmation").prop('disabled', true);
        $("#btnTransmettre").prop("disabled", true);
    }

    function AfficheValeur() {
        $("#NomTerritoire").empty().append($("[name='Territoire']").val() + SautDeLigne(2));
        $("#DateAvis").empty().append($("[name='DateDebut']").val() + SautDeLigne(2));
    }

    function InitialiserChamps() {
        $("[name='Territoire']").val("");
        $("[name='IdTerritoireDDL']").val("");
        $("#NomTerritoire").empty().append(SautDeLigne(2));
        $("[name='DateDebut']").val("");
        $("#DateAvis").empty().append(SautDeLigne(2));
        $("input[name=Decision]").prop('checked', false);
        ValidationActiveChampDate();
    }

    function ObtenirNomTerritoire(informationTerritoire) {
        var nomTerritoire = "";
        $.ajax({
            cache: false,
            type: 'POST',
            url: controlleurCommun.ObtenirNomTerritoire,
            contentType: "application/json",
            data: JSON.stringify({
                information: informationTerritoire
            }),
            async: false,
            success: function (nom) {
                nomTerritoire = nom;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction javascript ObtenirNomTerritoire");
            }
        });
        return nomTerritoire;
    }

    //TODO: À utilisé la fonction commune...
    function GenereIDTerritoire(territoire) {
        var idTerritoire;
        if (territoire.Code != "" && territoire.Code != null &&
            territoire.Type != "" && territoire.Type != null) {
            idTerritoire = territoire.Type + territoire.Code;
        }
        else {
            idTerritoire = territoire.NumeroSequentiel;
        }
        return idTerritoire;
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

    function AfficherNomPrenomProfessionnel(texte) {
        $("#NomPrenomProfessionnel").text(texte);
    }

    function ViderInformationProfessionnel() {
        $("#NomPrenomProfessionnel").text("");
        $("#TextDDL").val("");
        $("#IdDDL").val("");
    }

    function CacherZoneAlertMessage() {
        $("#AlertAvis").css("display", "none");
    }

})(window, $);