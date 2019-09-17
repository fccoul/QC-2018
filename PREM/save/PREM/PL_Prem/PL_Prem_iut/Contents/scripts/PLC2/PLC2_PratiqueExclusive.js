(function (window, $) {

    var divPratiqueExclusive = $("#PratiqueExclusiveDiv");

    var moisPrem = [
		{ NumeroMois: 1, Mois: "Mars" },
		{ NumeroMois: 2, Mois: "Avril" },
		{ NumeroMois: 3, Mois: "Mai" },
		{ NumeroMois: 4, Mois: "Juin" },
		{ NumeroMois: 5, Mois: "Juillet" },
		{ NumeroMois: 6, Mois: "Aout" },
		{ NumeroMois: 7, Mois: "Septembre" },
		{ NumeroMois: 8, Mois: "Octobre" },
		{ NumeroMois: 9, Mois: "Novembre" },
		{ NumeroMois: 10, Mois: "Decembre" },
		{ NumeroMois: 11, Mois: "Janvier" },
		{ NumeroMois: 12, Mois: "Fevrier" }
    ];

    ///<remarks>
    ///prise en compte de la demande 26 : La notion "Absence d'avis" doit être remplacée par "Absence d'avis de conformité" dans l'ensemble des panoramas.
    ///</remarks>
    // Description pour les engagements de pratique
    var DESCRIPTION_ABSENCE_AVIS_CONFORMITE = "Absence d’avis de conformité";
    var DESCRIPTION_DEROGATION_IVN = "Instance à vocation nationale";

    // ### Initialisation des événements ###
    $(document).ready(function () {
    });

    // Permet de charger les informations du profil de pratique exclusive
    function ObtenirInformationPratiqueExclusive() {
        $.ajax({
            url: divPratiqueExclusive.data('request-url'),
            type: "GET",
            cache: false,
            success: function (html) {

                if (RAMQ.Web.PLC2.ValiderDroitDRMG() == "True") {
                    RAMQ.Web.PLC2.InactiverOngletDRMG();
                }
                else {
                    RAMQ.Web.PLC2.AjouterHtmlDiv(divPratiqueExclusive, html);

                    RAMQ.Web.PLC2.InitialisationSelect2();

                    $("#EngagementPratiqueExclusive").change(function () {
                        AfficherInformationEngagementSelectioner();
                        ObtenirPratiqueExclusive()
                    });

                    SelectionnerAnnee();
                    $("#AnneePratique").trigger('change');
                }

                RAMQ.Web.PLC2_RegionPratiquePartielleRestreinte.ObtenirInformationRegionPratiquePartielleRestreinte();
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX du chargement de l'onglet Profil de pratique exclusive");
            }
        });
    }

    // Permet de traiter le changement d'année dans le dropdown
    function SelectionnerAnnee() {

        $("#AnneePratique").change(function () {

            $("#EngagementPratiqueExclusive").empty();
            ObtenirEngagementPratique($("#AnneePratique").select2("val"));

        });

    }

    // Permet d'obtenir les engagements de pratiques
    function ObtenirEngagementPratique(annee) {

        var donnees = [];

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirEngagementSelonAnnee,
            contentType: "application/json",
            data: JSON.stringify({ annee: annee }),
            async: false,
            success: function (engagements) {

                for (i = 0; i < engagements.length; i++) {
                    if (engagements[i] !== "") {
                        donnees.push({ id: engagements[i].Value, text: engagements[i].Text });
                    }
                }

                $("#EngagementPratiqueExclusive").select2({
                    language: "fr",
                    placeholder: "",
                    allowClear: true,
                    minimumResultsForSearch: -1,
                    data: donnees
                });

                if ($("#EngagementPratiqueExclusive").select2("data").length > 0) {
                    $('#EngagementPratiqueExclusive option').eq(0).prop('selected', true);
                    $('#EngagementPratiqueExclusive').trigger('change');
                    //EffacerTableaux();
                }
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirEngagementPratique");
            }
        });
    }

    // Permet d'obtenir les pratiques exclusives
    function ObtenirPratiqueExclusive() {

        var anneeSelectionner = $("#AnneePratique").select2("val");
        var numeroSequenceEngagement = $("#EngagementPratiqueExclusive").select2("val");

        var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagement);

        var periode = RAMQ.Web.PLC2.DefinirPeriodePREM(engagement, anneeSelectionner);

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirPratiqueExclusive,
            data: {
                dateDebut: RAMQ.Web.PLC2.FormatDate(periode.DateDebut),
                dateFin: RAMQ.Web.PLC2.FormatDate(periode.DateFin),
                anneeSelectionner: anneeSelectionner
            },
            success: function (JourneesFacturationRSS) {
                $('#ZoneTableauPratiqueExclusive')[0].innerHTML = '';
                ConstruireTableau(anneeSelectionner, numeroSequenceEngagement, JourneesFacturationRSS);
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirPratiqueExclusive");
            }
        });
    }

    // Permet de construire le tableau à afficher
    function ConstruireTableau(annee, numeroSequenceEngagement, JourneesFacturationRSS) {

        var enteteTableDepannage =
			"<table class='table table-striped table-header-rotated'>" +
			"   <thead id='enteteDepannage'>" +
			"       <tr>" +
			"           <th>Période</th>" +
			"           <th class='RssEngagementSelectionner'></th>" +
			"           <th>Somme de toutes les journées en dépannage</th>" +
			"           <th>Total des jours admissibles</th>" +
			"       </tr>" +
			"   </thead>";
        var corpsTableDepannage =
			"   <tbody>";



        var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagement);
        var periodeMois = RAMQ.Web.PLC2.DefinirPeriodeMois(engagement, annee);

        for (var i = periodeMois.MoisDebut; i <= periodeMois.MoisFin ; i++) {

            var entiteMois = $.grep(moisPrem, function (e) {
                return e.NumeroMois == i;
            });

            corpsTableDepannage += "<tr id=" + entiteMois[0].Mois + "Depannage>";

            if (entiteMois[0].Mois == "Janvier" || entiteMois[0].Mois == "Fevrier") {
                corpsTableDepannage += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + (parseInt(annee) + 1).toString() + "</td>";
            }
            else {
                corpsTableDepannage += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + annee + "</td>";
            }
            corpsTableDepannage += "</tr>";

        }

        corpsTableDepannage +=
				 "      <tr id='TotalJoursAdmissibleDepannage'>" +
				 "         <td>Total des jours admissibles</td>" +
				 "      </tr>" +
				 "      <tr id='ProportionJoursAdmissibleDepannage'>" +
				 "         <td>Proportion des jours admissibles</td>" +
				 "      </tr>" +
				 "   </tbody>";

        corpsTableDepannage += "</table>";

        var enteteTableIVN =
			"<table class='table table-striped table-header-rotated'>" +
			"   <thead id='enteteIVN'>" +
			"       <tr>" +
			"           <th>Période</th>" +
			"           <th>Somme de toutes les journées en IVN</th>" +
			"           <th>Total des jours admissibles</th>" +
			"       </tr>" +
			"   </thead>";

        var corpsTableIVN =
			"   <tbody>";

        for (var i = periodeMois.MoisDebut; i <= periodeMois.MoisFin ; i++) {

            var entiteMois = $.grep(moisPrem, function (e) {
                return e.NumeroMois == i;
            });
            corpsTableIVN += "<tr id=" + entiteMois[0].Mois + "IVN>";

            if (entiteMois[0].Mois == "Janvier" || entiteMois[0].Mois == "Fevrier") {
                corpsTableIVN += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + (parseInt(annee) + 1).toString() + "</td>";
            }
            else {
                corpsTableIVN += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + annee + "</td>";
            }
            corpsTableIVN += "</tr>";

        }

        corpsTableIVN +=
				 "      <tr id='TotalJoursAdmissibleIVN'>" +
				 "         <td>Total des jours admissibles</td>" +
				 "      </tr>" +
				 "      <tr id='ProportionJoursAdmissibleIVN'>" +
				 "         <td>Proportion des jours admissibles</td>" +
				 "      </tr>" +
				 "   </tbody>";

        corpsTableIVN += "</table>";


        var tableauDepannage = enteteTableDepannage + corpsTableDepannage;
        var tableauIVN = enteteTableIVN + corpsTableIVN;

        $("#ZoneTableauPratiqueExclusive").append(tableauDepannage + tableauIVN);

        RemplirTableauDepannage(annee, numeroSequenceEngagement, JourneesFacturationRSS);
        RemplirTableauIVN(annee, numeroSequenceEngagement, JourneesFacturationRSS);
        RemplirCelluleVide();

    }

    // Permet de remplir les tableau de dépannage
    function RemplirTableauDepannage(annee, engagement, JourneesFacturationRSS) {

        var RssEnCours = null;
        var rss = "";
        var rssTrouver = "";
        var anneeTemporaire;

        if (JourneesFacturationRSS !== null && JourneesFacturationRSS !== null) {
            for (var i = 0; i < JourneesFacturationRSS.length; i++) {
                var valeur = "";

                // Vérifie si le RSS en cours est différent du précédent
                if (RssEnCours !== JourneesFacturationRSS[i].RSS) {

                    if (JourneesFacturationRSS[i].RSS !== null) {

                        rss += "<th>" + RAMQ.Web.PLC2.ObtenirNomRSS(JourneesFacturationRSS[i].RSS) + "</th>"

                        RssEnCours = JourneesFacturationRSS[i].RSS;
                    }
                    else {
                        RssEnCours = null;
                    }
                }

                var chiffreMois = JourneesFacturationRSS[i].Mois;

                if (chiffreMois !== null) {
                    var mois = RAMQ.Web.PLC2.ObtenirMoisSelonChiffre(chiffreMois)
                    if (mois == "Janvier" || mois == "Fevrier") {
                        anneeTemporaire = parseInt(annee) + 1;
                    }
                    else {
                        anneeTemporaire = annee;
                    }

                    if (JourneesFacturationRSS[i].TypeJours == "Dpnag" && JourneesFacturationRSS[i].Annee == anneeTemporaire) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                    }
                    else if (JourneesFacturationRSS[i].TypeJours == "TotalPratiExcl" && JourneesFacturationRSS[i].Annee == anneeTemporaire) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                    }

                    if (valeur !== "") {
                        $("#" + mois + "Depannage").append("<td>" + ArrondirNombre(valeur.NombreJours) + "</td>");
                    }
                }
                else {


                    if (JourneesFacturationRSS[i].RSS !== null && (rssTrouver.indexOf(JourneesFacturationRSS[i].RSS) == -1) && JourneesFacturationRSS[i].Mois == null && JourneesFacturationRSS[i].Annee == null) {

                       var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                    }
                    else if (JourneesFacturationRSS[i].RSS == null && JourneesFacturationRSS[i].Mois == null && JourneesFacturationRSS[i].Annee == null) {

                        if (JourneesFacturationRSS[i].TypeJours == "Dpnag") {
                            var valeur = {
                                NombreJours: JourneesFacturationRSS[i].NombreJours,
                                Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                            };
                        }
                        else if (JourneesFacturationRSS[i].TypeJours == "TotalPratiExcl") {
                            var valeur = {
                                NombreJours: JourneesFacturationRSS[i].NombreJours,
                                Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                            };
                        }
                    }

                    if (valeur !== "") {
                        rssTrouver += rssTrouver + JourneesFacturationRSS[i].RSS + ",";

                        $("#TotalJoursAdmissibleDepannage").append("<td>" + ArrondirNombre(valeur.NombreJours) + "</td>");
                        $("#ProportionJoursAdmissibleDepannage").append("<td>" + ArrondirNombre(valeur.Pourcentage) + "%</td>");
                    }


                }

            }

            rss = rss.replace("<th></th>", "");
            $("th.RssEngagementSelectionner").replaceWith(rss);

        }

    }

    // Permet de remplir les tableau de dépannage
    function RemplirTableauIVN(annee, engagement, JourneesFacturationRSS) {

        var valeur;
        var anneeTemporaire;
       

        if (JourneesFacturationRSS !== null && JourneesFacturationRSS !== null) {
            for (var i = 0; i < JourneesFacturationRSS.length; i++) {

                valeur = "";

                var chiffreMois = JourneesFacturationRSS[i].Mois;

                if (chiffreMois !== null) {
                    var mois = RAMQ.Web.PLC2.ObtenirMoisSelonChiffre(chiffreMois)
                    if (mois == "Janvier" || mois == "Fevrier") {
                        anneeTemporaire = parseInt(annee) + 1;
                    }
                    else {
                        anneeTemporaire = annee;
                    }

                    if (JourneesFacturationRSS[i].TypeJours == "IVN" && JourneesFacturationRSS[i].Annee == anneeTemporaire && JourneesFacturationRSS[i].Mois == chiffreMois && JourneesFacturationRSS[i].RSS == null) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                       
                    }
                    else if (JourneesFacturationRSS[i].TypeJours == "TotalPratiExcl" && JourneesFacturationRSS[i].Annee == anneeTemporaire && JourneesFacturationRSS[i].Mois == chiffreMois && JourneesFacturationRSS[i].RSS == null) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                    }

                    if (valeur !== "") {
                        $("#" + mois + "IVN").append("<td>" + ArrondirNombre(valeur.NombreJours) + "</td>");
                    }
                }
                else {
                    if (JourneesFacturationRSS[i].TypeJours == "IVN" && JourneesFacturationRSS[i].Annee == null && JourneesFacturationRSS[i].Mois == null && JourneesFacturationRSS[i].RSS == null) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                        
                    }
                    else if (JourneesFacturationRSS[i].TypeJours == "TotalPratiExcl" && JourneesFacturationRSS[i].Annee == null && JourneesFacturationRSS[i].Mois == null && JourneesFacturationRSS[i].RSS == null) {
                        var valeur = {
                            NombreJours: JourneesFacturationRSS[i].NombreJours,
                            Pourcentage: valeur.Pourcentage = JourneesFacturationRSS[i].Pourcentage
                        };
                        
                    }

                    if (valeur !== "") {

                        $("#TotalJoursAdmissibleIVN").append("<td>" + ArrondirNombre(valeur.NombreJours) + "</td>");
                        $("#ProportionJoursAdmissibleIVN").append("<td>" + ArrondirNombre(valeur.Pourcentage) + "%</td>");
                    }

                }

            }

        }

    }

    function ObtenirValeurListeJourneesFacturerRSS(rss, typeJour, annee, mois, journeesFacturationRSS) {

        var valeur = $.grep(moisPrem, function (e) {
            return e.NumeroMois == i;
        });



    }

    // Permet de remplir les cellules vides
    function RemplirCelluleVide() {
        var nombreColonneEnteteDepannage = $("#enteteDepannage").children().children().length;
        var nombreColonneEnteteIVN = $("#enteteIVN").children().children().length;

        for (var i = 0; i < moisPrem.length; i++) {

            if ($("#" + moisPrem[i].Mois + "Depannage").length > 0) {
                while ($("#" + moisPrem[i].Mois + "Depannage").children().length < nombreColonneEnteteDepannage) {
                    $("#" + moisPrem[i].Mois + "Depannage").append("<td></td>");
                }
            }

            if ($("#" + moisPrem[i].Mois + "IVN").length > 0) {
                while ($("#" + moisPrem[i].Mois + "IVN").children().length < nombreColonneEnteteIVN) {
                    $("#" + moisPrem[i].Mois + "IVN").append("<td></td>");
                }



            }
        }

        while ($("#TotalJoursAdmissibleDepannage").children().length < nombreColonneEnteteDepannage) {
            $("#TotalJoursAdmissibleDepannage").append("<td></td>")
        }

        while ($("#ProportionJoursAdmissibleDepannage").children().length < nombreColonneEnteteDepannage) {
            $("#ProportionJoursAdmissibleDepannage").append("<td></td>")
        }

        while ($("#TotalJoursAdmissibleIVN").children().length < nombreColonneEnteteIVN) {
            $("#TotalJoursAdmissibleIVN").append("<td></td>")
        }

        while ($("#ProportionJoursAdmissibleIVN").children().length < nombreColonneEnteteIVN) {
            $("#ProportionJoursAdmissibleIVN").append("<td></td>")
        }
    }

    // Permet d'afficher l'information de l'engagement sélectionné
    function AfficherInformationEngagementSelectioner() {

        $('#InformationEngagementPratiqueExclusive')[0].innerHTML = '';

        var numeroSequenceEngagementSelectionner = $("#EngagementPratiqueExclusive").select2("val");

        if (numeroSequenceEngagementSelectionner !== null) {
            var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagementSelectionner);
            var dateDebut = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut));
            var dateFin = "- - - -";

            if (engagement.Periode.DateFin !== null) {
                dateFin = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin));
            }

            var information = engagement.Description;

            if (engagement.Description == "Dérogation" || engagement.Description == "Autorisation") {
                ///<remarks>
                ///prise en compte de la demande 26 : Lors de la sélection du type d'engagement, le libellé "IVN" doit être remplacé par "Dérogation - Instance à vocation nationale" 
                ///</remarks>
                if (engagement.Type == "IVN") {
                    information += " - " + DESCRIPTION_DEROGATION_IVN;
                }
                else {
                    information += " - " + engagement.Type;
                }
            }
            else if (engagement.Description == "Avis de conformité") {
                information += " - " +engagement.Territoire.Nom;
            }
                ///<remarks>
                ///prise en compte de la demande 26 : La notion "Absence d'avis" doit être remplacée par "Absence d'avis de conformité" dans l'ensemble des panoramas.
                ///</remarks>
            else {
                information = DESCRIPTION_ABSENCE_AVIS_CONFORMITE
            }

            information += " - " + dateDebut + " au " + dateFin;

            $("#InformationEngagementPratiqueExclusive").append(information);
        }
    }

   
    // Permet de savoir si le nombre est de type float
    function EstFloat(n) {
        return Number(n) === n && n % 1 !== 0;
    }

    // Permet d’arrondir un nombre
    function ArrondirNombre(nombre) {
        if (EstFloat(nombre)) {
            return parseFloat(Math.round(nombre * 100) / 100).toFixed(2);
        }
        else {
            return nombre;
        }
    }

    // ### Interfaces ###
    if ("undefined" == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ("undefined" == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ("undefined" == typeof (window.RAMQ.Web.PLC2_PratiqueExclusive))
        window.RAMQ.Web.PLC2_PratiqueExclusive = {
            "ObtenirInformationPratiqueExclusive": ObtenirInformationPratiqueExclusive
        };

})(window, $);