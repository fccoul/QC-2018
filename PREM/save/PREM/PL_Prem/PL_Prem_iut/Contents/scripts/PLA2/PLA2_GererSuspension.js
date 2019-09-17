(function (window, $) {

    var listeAvis = null;

    $(document).ready(function () {
        ObtenirInformationProfessionnel();

        $("#MessageInformation").html("").css("display", "none");
       
        $("#AvisConformite").select2({
            language: "fr",
            allowClear: true,
            width: "429px",
            placeholder: "",
            minimumResultsForSearch: "Infinity"
        });

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
            $("#boutonRechercherProfessionnel").click();
        }
    });

    $("#AvisConformite").change(function () {

        if ($("#AvisConformite").select2("val") !== "") {
            $("#ListeGroupeSuspension")[0].innerHTML = '';
            $("#LabelSuspension")[0].innerHTML = '';
            RemplirTableauSuspension();
        }
       
        

    })

    function ObtenirInformationProfessionnel() {

        $("#boutonRechercherProfessionnel").click(function (event) {
            var numeroPratique = $("#NumeroPratique").val();
           
            InitialisationChamps();

            // Permet d'enlever le focus du texbox comme si l'usager aurait cliquer sur le bouton
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
                            ObtenirLesAvisConformite(obj.NumeroSequentielDispensateur, numeroPratique)
                            $("#NomPrenomProfessionnel").text(obj.NomAffichage);
                            $("[name='IdentiteMedecin']").val(numeroPratique + " - " + obj.NomAffichage);
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
            else {
                $("#NomPrenomProfessionnel").text("");
                $("#MessageInformation").html("").css("display", "none");
            }

        });
    }


    function ObtenirLesAvisConformite(numeroSequenceDispensateur, numeroPratique) {

        $.ajax({
            type: 'POST',
            url: controlleurPLA2.ObtenirAvisConformiteSansAnnulerRevoquer,
            data: { numeroSequenceDispensateur: numeroSequenceDispensateur },
            success: function (obj) {

                listeAvis = null;
                $("#MessageInformation").html("").css("display", "none");
                // Permet la réinitialisation des <option> dans la liste des avis de conformité
                $("#AvisConformite").html('').select2({ data: [{ id: '', text: '' }] });
                if (obj.ListeAvisConformite.length > 0) {
                    $("#AvisConformite").select2("val", "");
                    RemplirListeAvisConformite(obj.ListeAvisConformite);
                    $('#AvisConformite').prop("disabled", false);
                    $("#ZoneSuspensions").prop("hidden", false);
                    $("#ZoneAjoutSuspension").prop("hidden", false);


                }
                else {
                    $("#MessageInformation").html(obj.InfoMsgTrait[0].TxtMsgFran).css("display", "block");
                    $('#AvisConformite').prop("disabled", true);
                    $("#ZoneSuspensions").prop("hidden", true);
                    $("#ZoneAjoutSuspension").prop("hidden", true);
                    $("#AvisConformite").select2("val", "");
                }
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirLesAvisConformite");
            }
        });

    }


    function RemplirListeAvisConformite(avis) {
        var donnees = [];
        var nomTerritoire = null;
        var dateDebut = null;
        var dateFin = null;

        for (i = 0; i < avis.length; i++) {
            nomTerritoire = ObtenirNomTerritoire(avis[i]);
            dateDebut = FormatterDate(FormatterJsonDate(avis[i].DateDebutEngagement));

            if (avis[i].DateFinEngagement == null) {
                dateFin = '----------';
            }
            else {
                dateFin = FormatterDate(FormatterJsonDate(avis[i].DateFinEngagement));
            }

            donnees.push({ id: avis[i].NumeroSequentielEngagement, text: nomTerritoire.concat(" - ", dateDebut, " au ", dateFin) });
        }

        $("#AvisConformite").select2({
            language: "fr",
            allowClear: true,
            width: "429px",
            minimumResultsForSearch: "Infinity",
            placeholder: "",
            data: donnees
        });


        listeAvis = avis;
        $('#AvisConformite option').eq(1).prop('selected', true).change();
    };

    function ObtenirNomTerritoire(avis) {

        var informationTerritoire = {
            NumeroSequentiel: avis.NumeroSequentielRegroupement,
            Type: avis.TypeLieuGeographique,
            Code: avis.CodeLieuGeographique,
            DateDebutPratique: FormatterJsonDate(avis.DateDebutEngagement)
        };

        $.ajax({
            type: 'POST',
            url: controlleurCommun.ObtenirNomTerritoireSelonAvisConformite,
            contentType: "application/json",
            data: JSON.stringify({ information: informationTerritoire }),
            async: false,
            success: function (nom) {
                nomTerritoire = nom;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirNomTerritoireSelonAvisConformite");
            }
        });
        return nomTerritoire;
    };

    function RemplirTableauSuspension() {

        if (listeAvis !== null) {

            var selection = document.getElementById("AvisConformite");
            var valeurAvis = selection.options[selection.selectedIndex].value;
            var avisSelectionner = null;
            var suspension = null
            var dateDebut = null;
            var dateFin = null;
            var informationSuspension = null;
            var contientSuspension = false;


            for (i = 0; i < listeAvis.length; i++) {


                if (listeAvis[i].NumeroSequentielEngagement == valeurAvis) {
                    avisSelectionner = listeAvis[i];
                }
            }


            if (avisSelectionner !== null) {

                for (i = 0; i < avisSelectionner.ListeStatutAvisConformite.length; i++) {


                    suspension = avisSelectionner.ListeStatutAvisConformite[i];

                    if (suspension.DateHeureOccurenceInactive == null && suspension.StatutEngagement == 'SUS') {


                        dateDebut = FormatterDate(FormatterJsonDate(suspension.DateDebutStatutEngagement));
                        if (suspension.DateFinStatutEngagement !== null) {
                            dateFin = FormatterDate(FormatterJsonDate(suspension.DateFinStatutEngagement));
                        }
                        else { datefin = ''; }

                        informationSuspension = ObtenirTypeSuspension(suspension.CodeRaisonStatutEngagement).concat("<br />", dateDebut, " au ", dateFin);

                        $("#ListeGroupeSuspension").append(
                            "<div class='list-group-item'>" +
                            "   <div class='list-group-item-text clearfix'>" +
                            "       <div class='row'>" +
                            "           <div class='col-md-9'>" +
                                            informationSuspension +
                            "           </div>" +
                            "           <div class='col-md-3 text-right'>" +
                            "               <button id='Annuler" + i + "' type='submit' class='btn-xs btn-primary' name='NumeroSequentiel' value=" + suspension.NumeroSequentielStatutEngagement + ">Annuler</button>" +
                            "               <button id='Modifier" + i + "' type='submit' class='btn-xs btn-primary' name='NumeroSequentiel' value=" + suspension.NumeroSequentielStatutEngagement + ">Modifier</button>" +
                            "           </div>" +
                            "       </div>" +
                            "   </div>" +
                            "</div>");

                        $("#Annuler" + i).click(function () {
                            GererModeAffichage("Annuler");
                        });

                        $("#Modifier" + i).click(function () {
                            GererModeAffichage("Modifier");
                        });
                    }
                }

                if ($("#ListeGroupeSuspension")[0].innerHTML == '') {
                    $("#MessageInformation").html(ObtenirTextMessageErreur(148019)).css("display", "block");
                }
                else {
                    $("#MessageInformation").html("").css("display", "none");
                    $("#LabelSuspension")[0].innerHTML = "<label class='control-label'>Suspensions</label>";
                }

                $("#ZoneGroup").append(
                               "<div class='row' id='RowZoneAjoutSuspension'>" +
                               "   <div class='form-group col-md-12' id='ZoneAjoutSuspension' hidden='hidden'>" +
                               "        <button id='Ajouter' type='submit' class='btn btn-primary' name='NumeroPratique' value=" + $("#NumeroPratique").val() + "><i class='glyphicon glyphicon-plus-sign' aria-hidden='true'></i> Ajouter une suspension</button>" +
                               "   </div>" +
                               "</div>");

                $("#Ajouter").click(function () {
                    GererModeAffichage("Ajouter");
                });
            }

        }

    };

    function GererModeAffichage(modeAffichage) {
        var selection = document.getElementById("AvisConformite");

        $("[name='ModeAffichage']").val(modeAffichage);
        $("[name='DescriptionAvisConformite']").val(selection.options[selection.selectedIndex].text);
    };

    function ObtenirTextMessageErreur(numeroMessage) {
        $.ajax({
            type: 'POST',
            url: controlleurPLA2.ObtenirTextMessageErreur,
            contentType: "application/json",
            data: JSON.stringify({ idMessage: numeroMessage }),
            async: false,
            success: function (text) {
                valeurMessage = text;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirTextMessageErreur");
            }
        });
        return valeurMessage;
    };

    function ObtenirTypeSuspension(codeRaisonStatut) {
        $.ajax({
            type: 'POST',
            url: controlleurPLA2.ObtenirDescriptionCodeRaisonStatutEngagement,
            contentType: "application/json",
            data: JSON.stringify({ codeRaisonStatutEngagement: codeRaisonStatut }),
            async: false,
            success: function (text) {
                valeurTypeSuspension = text;
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirTypeSuspension");
            }
        });

        return valeurTypeSuspension;
    };

    function PlacerCurseurDernierCaractere() {

        var textBoxRecherche = $('#NumeroPratique');

        var longeurNumeroPratique = textBoxRecherche.val().length * 2;

        textBoxRecherche.focus();
        textBoxRecherche[0].setSelectionRange(longeurNumeroPratique, longeurNumeroPratique);
    };

    function InitialisationChamps() {
        $("#NomPrenomProfessionnel").text("");

        $("#AvisConformite").select2("val", "");

        $("#LabelSuspension")[0].innerHTML = '';
        $("#ListeGroupeSuspension")[0].innerHTML = '';
        $("#AvisConformite").prop("disabled", true);

        if ($("#RowZoneAjoutSuspension").length) {
           
            $("#RowZoneAjoutSuspension")[0].innerHTML = '';
        }
        
    }

})(window, $);