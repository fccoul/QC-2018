(function (window, $) {

    $(document).ready(function () {

        $("#AnnulerDerogation").prop("disabled", true);
        ObtenirInformationProfessionnel();
        $("#MessageInformation").html("").css("display", "none");

        // Permet d'empêcher la "POST" de la page lors qu'on appuis sur "ENTER"
        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                $("#boutonRechercherProfessionnel").click();
            }
        });

        $("#NumeroPratique").focus();
    });


    function ObtenirInformationProfessionnel() {      

        $("#boutonRechercherProfessionnel").click(function (event) {

            var numeroPratique = $("#NumeroPratique").val();
            InitialisationChamps();
            $("#boutonRechercherProfessionnel").focus();

            if (numeroPratique.length == 6 && numeroPratique.charAt(0) == "1") {
                $.ajax({
                    type: 'POST',
                    url: controlleurCommun.ObtenirProfessionnelRecherche,
                    data: {
                        NumeroPratique: numeroPratique,
                        ClassesPossible: [1]
                    },
                    success: function (obj) {
                        $("#MessageInformation").html("").css("display", "none");
                        if (obj.MessageErreurs.length == 0 && obj.NumeroSequentielDispensateur > 0) {
                            ObtenirDerogation(obj.NumeroSequentielDispensateur)
                            $("#NomPrenomProfessionnel").text(obj.NomAffichage);
                            $("[name='IdentiteMedecin']").val(numeroPratique + " - " + obj.NomAffichage);
                            $("[name='NumeroSequentielDispensateur']").val(obj.NumeroSequentielDispensateur);
                        }
                        else {
                            var textErreur = "";
                            for (var i = 0; i < obj.MessageErreurs.length; i++) {
                                textErreur = textErreur + obj.MessageErreurs[i] + "<br />";
                            }
                            if (textErreur != "") {
                                $("#MessageInformation").html(textErreur).css("display", "block");
                            }
                            

                        }
                    },
                    error: function (err) {
                        ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationProfessionnel");
                    }
                });
            }

        });

    }

    function ObtenirDerogation(numeroSequentielDispensateur) {
        $.ajax({
            type: 'POST',
            url: controlleurPLA2.ObtenirDerogation,
            data: { numeroSequentielDispensateur: numeroSequentielDispensateur },
            success: function (obj) {
                if (obj.Derogations.length > 0) {
                    $("#MessageInformation").html("").css("display", "none");
                    $("#TypeDerogation").html(ObtenirDescriptionTypeDerogation(obj.Derogations[0].Type));
                    $("#Type").val(obj.Derogations[0].Type);
                    $("#DateDebutDerogation").html(FormatterDate(FormatterJsonDate(obj.Derogations[0].DateDebut)));
                    $("#DateDebut").val(FormatterDate(FormatterJsonDate(obj.Derogations[0].DateDebut)));
                    $("#EstRenseignementConfirmer").prop('disabled', false);
                    $("#NumeroSequentiel").val(obj.Derogations[0].NumeroSequentiel);

                    if (ValiderGroupeSupport()) {
                        $("#AnnulerDerogation").prop('disabled', true);
                    }
                    else {
                        $("#AnnulerDerogation").prop('disabled', false);
                    }


                }
                else {
                    $("#MessageInformation").html(obj.InfoMsgTrait[0].TxtMsgFran).css("display", "block");
                    $("#TypeDerogation").html('');
                    $("#DateDebutDerogation").html('');
                    $("#EstRenseignementConfirmer").prop('disabled', true);
                    $("#EstRenseignementConfirmer").prop('checked', false);
                    $("#NumeroSequentiel").val('');
                    $("#Type").val('');
                    $("#DateDebut").val('');
                    $("#AnnulerDerogation").prop('disabled', true);
                }
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirDerogation");
            }
        });
    }

    function ObtenirDescriptionTypeDerogation(typeDerogation) {
        $.ajax({
            type: 'POST',
            url: controlleurPLA2.ObtenirDescriptionTypeDerogation,
            contentType: "application/json",
            data: JSON.stringify({ typeDerogation: typeDerogation }),
            async: false,
            success: function (text) {
                descriptionTypeDerogation = text;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirDescriptionTypeDerogation");
            }
        });

        return descriptionTypeDerogation;
    }

    function InitialisationChamps() {
        $("#NomPrenomProfessionnel").text("");

        $("#TypeDerogation").html("");
        $("#DateDebutDerogation").html("");
        $("#EstRenseignementConfirmer").prop('checked', false);

        if ($("#MessageInformation").html() !== "") {
            $("#AnnulerDerogation").prop('disabled', true);
        }
        else {
            $("#AnnulerDerogation").prop('disabled', true);
        }
       

    }

})(window, $);