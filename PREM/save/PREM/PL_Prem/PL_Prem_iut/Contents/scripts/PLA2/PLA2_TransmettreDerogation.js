(function (window, $) {

    $(document).ready(function () {

        $("#Transmettre").prop("disabled", true);

        ObtenirInformationProfessionnel()
       

        var valider = $('#Valider').val();

        if (valider == "True") {
            ConfirmationDerogation()
            $("#ButtonOui").click(function () {
                Retransmettre();
            });
        }

        if ($("#MessageInformation").val() !== "") {
            $("#MessageInformation").css("display", "block")
            $("#MessageInformation").html($("#MessageInformation").val());
        }
        else {
            $("#MessageInformation").css("display", "none")
            $("#MessageInformation").html("");
        }
            
        // Permet d'empêcher la "POST" de la page lors qu'on appuis sur "ENTER"
        $('#NumeroPratique').keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                $("#boutonRechercherProfessionnel").click();
            }
        });

        $("#NumeroPratique").focus();
        if ($("#NumeroPratique").val() != null && $("#NumeroPratique").val() != "") {

            PlacerCurseurDernierCaractere();
        }

        ActiveDesactiveDate();
        ActiveDesactiveTypeDerogation();
        ActiveDesactiveCaseACocher();
        ActiveDesactiveBoutonTransmettre();

        window.onload = function () {

            var nomPrenomProfessionnel = sessionStorage.getItem('nomPrenomProfessionnel');
            if (nomPrenomProfessionnel !== "" && $("#NumeroPratique").val().length == 6) {
                $('#NomPrenomProfessionnel').text(nomPrenomProfessionnel);
            }
        }

        window.onbeforeunload = function () {
            sessionStorage.setItem('nomPrenomProfessionnel', $('#NomPrenomProfessionnel').text());
        }



    });

    function ObtenirInformationProfessionnel() {

        $("#boutonRechercherProfessionnel").click(function (event) {
            var numeroPratique = $("#NumeroPratique").val();

            InitialisationChamps();

            // Permet d'enlever le focus du textbox comme si l'usager aurait cliquer sur le bouton
            // et force la validation du champs
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
                            ValidationEngagementActif(obj.NumeroSequentielDispensateur)
                            $("#NomPrenomProfessionnel").text(obj.NomAffichage);
                            $("[name='NumeroSequentielDispensateur']").val(obj.NumeroSequentielDispensateur);
                            ActiverChamp();
                        }
                        else {
                            var textErreur = "";
                            for (var i = 0; i < obj.MessageErreurs.length; i++) {
                                textErreur = textErreur + obj.MessageErreurs[i] + "<br />";
                            }
                            if (textErreur !== "") {
                                $("#MessageInformation").html(textErreur).css("display", "block");
                            }
                            

                        }
                    },
                    error: function (err) {
                        ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirInformationProfessionnel");
                    }
                });
            }
            else {
                $("#NomPrenomProfessionnel").text("");
                $("#MessageInformation").html("").css("display", "none");
            }

        });
    }

    function ConfirmationDerogation() {
        $('#ConfirmationModal').modal({ show: true });

        return false;
    }

    function Retransmettre() {
        $('#Continuer').val("True");
    }

    function ActiverChamp() {
        $("#Type").prop('disabled', false);
        $("#EstRenseignementConfirmer").prop('disabled', false);
        $("#DateDebut").prop('disabled', false);
        InitialiseDatepicker();
    }

   

        $("#NumeroPratique").keyup(function () {
            ActiveDesactiveBoutonTransmettre();
        });

        $("#Type").change(function () {
            ActiveDesactiveBoutonTransmettre();
        });

        $("#DateDebut").change(function () {
            DateOnChange();
        });
    

    function ValidationEngagementActif(numero) {
        $("#MessageInformation").html("");
        if (numero > 0) {
            $.ajax({
                type: 'POST',
                url: controlleurPLA2.ValidationEngagementActif,
                data: { numeroProfessionnel: numero },
                async: false,
                success: function (obj) {
                    $("#MessageInformation").html(obj.MessageAvertissement),
                    $("#MessageInformation").css("display", "block")
                    $("#MessageInformation").val(obj.MessageAvertissement)
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ValidationEngagementActif");
                }
            });
        }
        else {
            $("#MessageInformation").css("display", "none")
        }
    }

    function DateOnChange() {
        ActiveDesactiveBoutonTransmettre();
    }

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

    function ActiveDesactiveBoutonTransmettre() {
        var numeroPratique = $("#NumeroPratique").val();
        var typeDerogation = $("#Type").val();
        var dateDebut = $("#DateDebut").val();
        var estRenseignementConfirmer = $("#EstRenseignementConfirmer").prop('checked');

        if (numeroPratique.length == 6 &&
            typeDerogation != "" &&
            dateDebut != "" &&
            !ValiderGroupeSupport()) {
            $("#Transmettre").prop('disabled', false);
        } else {
            $("#Transmettre").prop('disabled', true);
        }
    }

    function ActiveDesactiveDate() {
        var numeroPratique = $("#NumeroPratique").val();
        if (numeroPratique.length == 6) {
            $("#DateDebut").prop('disabled', false);
            InitialiseDatepicker();
        } else {
            $("#DateDebut").prop('disabled', true);
            $("#DateDebut").val("").trigger('change');
            $(".datepicker").datepicker('remove');
        }
    }

    function ActiveDesactiveTypeDerogation() {
        var numeroPratique = $("#NumeroPratique").val();
        if (numeroPratique.length == 6) {
            $("#Type").prop('disabled', false);
        } else {
            $("#Type").prop('disabled', true);
            $("#Type").select2("val", "");
        }
    }

    function ActiveDesactiveCaseACocher() {
        var numeroPratique = $("#NumeroPratique").val();
        if (numeroPratique.length == 6) {
            $("#EstRenseignementConfirmer").prop('disabled', false);
        }
        else {
            $("#EstRenseignementConfirmer").prop('disabled', true);
            $("#EstRenseignementConfirmer").prop('checked', false);
        }
    }

    function PlacerCurseurDernierCaractere() {

        var textBoxRecherche = $('#NumeroPratique');

        var longeurNumeroPratique = textBoxRecherche.val().length * 2;

        textBoxRecherche.focus();
        textBoxRecherche[0].setSelectionRange(longeurNumeroPratique, longeurNumeroPratique);
    };

    function InitialisationChamps() {
        $("#DateDebut").val("");
        $("#Type").select2("val", "");
        $("#EstRenseignementConfirmer").prop('checked', false);
        $(".alert-danger").prop('hidden', true);
        $("#NomPrenomProfessionnel").text("");
    }

})(window, $);