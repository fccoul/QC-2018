(function (window, $) {

    var divRepartitionPratique = $("#RepartitionPratiqueDiv");

    var moisPrem = [
        { NumeroMoisPREM: 1, Mois: "Mars", NumeroMois: 3 },
        { NumeroMoisPREM: 2, Mois: "Avril", NumeroMois: 4 },
        { NumeroMoisPREM: 3, Mois: "Mai", NumeroMois: 5 },
        { NumeroMoisPREM: 4, Mois: "Juin", NumeroMois: 6 },
        { NumeroMoisPREM: 5, Mois: "Juillet", NumeroMois: 7 },
        { NumeroMoisPREM: 6, Mois: "Aout", NumeroMois: 8 },
        { NumeroMoisPREM: 7, Mois: "Septembre", NumeroMois: 9 },
        { NumeroMoisPREM: 8, Mois: "Octobre", NumeroMois: 10 },
        { NumeroMoisPREM: 9, Mois: "Novembre", NumeroMois: 11 },
        { NumeroMoisPREM: 10, Mois: "Decembre", NumeroMois: 12 },
        { NumeroMoisPREM: 11, Mois: "Janvier", NumeroMois: 1 },
        { NumeroMoisPREM: 12, Mois: "Fevrier", NumeroMois: 2 }
    ];

    // Types pour les territoires
    var TYPE_TERRITOIRE_RLS = "RLS";
    var TYPE_TERRITOIRE_RSS = "RSS";
    var TYPE_TERRITIORE_TERRITOIRE = "Territoire";
    var TYPE_TERRITOIRE_REGROUPEMENT = "Regroupement";

    // Description pour les engagements de pratique
    var DESCRIPTION_ABSENCE_AVIS_CONFORMITE = "Absence d’avis de conformité";
    var DESCRIPTION_ABSENCE_AVIS = "Absence d’avis";
    var DESCRIPTION_AVIS = "Avis de conformité";
    var DESCRIPTION_DEROGATION = "Dérogation";
    var DESCRIPTION_AUTORISATION = "Autorisation";

    var DESCRIPTION_DEROGATION_IVN="Instance à vocation nationale";

    // Type de pratique
    var TYPE_PRATIQUE_INTRA = "Intra";
    var TYPE_PRARTIQUE_INTER = "Inter";

    // Composantes d'affichage dans la page
    var LISTE_DEROULANTE_PRATIQUE = "#Pratique";
    var LISTE_DEROULANTE_ENGAGEMENT = "#EngagementPratiqueRepartition";
    var LISTE_DEROULANTE_ANNEE = "#AnneeRepartition";

    // Zone d'affichage
    var ZONE_INFORMATION_ENGAGEMENT = "#InformationEngagementRepartitionPratique";
    var ZONE_TABLEAU_REPARTITION = "#ZoneTableauRepartition";

    // Type de jour
    var TYPE_JOUR_DEPANNAGE_LOC = "PremDpnagLoc";
    var TYPE_JOUR_HORS_QUEBEC = "HQ";
    var TYPE_JOUR_HORS_QUEBEC_DEROGATION = "HQDerog";
    var TYPE_JOUR_TOTAL = "Total";
    var TYPE_JOUR_AUTRE = "Autre";
    var TYPE_JOUR_LOCALITE = "Localité";
    var TYPE_JOUR_LOCALITE_DEROGATION = "LocalitéDerog";
    var TYPE_JOUR_TOTAL_DEROGATION = "TotalDerog";

    // Statut
    var STATUT_SUSPENDU = "Suspendu";

    

    // ### Initialisation des événements ###
    $(document).ready(function () {
        
    });

    // Permet de charger les informations des répartitions interrégionale
    function ObtenirInformationRepartitionPratique() {

        $.ajax({
            url: divRepartitionPratique.data('request-url'),
            type: "GET",
            cache: false,
            success: function (html) {

                RAMQ.Web.PLC2.AjouterHtmlDiv(divRepartitionPratique, html);
                               
                RAMQ.Web.PLC2.InitialisationSelect2();

                $(LISTE_DEROULANTE_ENGAGEMENT).change(function () {

                    AfficherInformationEngagementSelectioner();
                    SelectionnerTypePratiqueDefaut();
                });

                $(LISTE_DEROULANTE_PRATIQUE).change(function () {
                    ObtenirRepartitionPratique();
                });


                //GererIconExpansionRanger();
                SelectionnerAnnee();

                $(LISTE_DEROULANTE_ANNEE).trigger('change');

                RAMQ.Web.PLC2_PratiqueExclusive.ObtenirInformationPratiqueExclusive();
            },
            error: function (err) {                
                ErreurTechnique(err, "Erreur pendant un appel AJAX du chargement de l'onglet Répartition de la pratique");
            }
        });
    }

    // Permet de traiter le changement d'année dans le dropdown
    function SelectionnerAnnee() {

        $(LISTE_DEROULANTE_ANNEE).change(function () {

   
            $(LISTE_DEROULANTE_ENGAGEMENT).empty().trigger('change')

            ObtenirEngagementPratique($(LISTE_DEROULANTE_ANNEE).select2("val"));

            if ($(LISTE_DEROULANTE_ANNEE).select2("val")<2016)
            {
                $(LISTE_DEROULANTE_PRATIQUE).attr('disabled', true);
            }
            else
            {
                $(LISTE_DEROULANTE_PRATIQUE).attr('disabled', false);
            }
        })

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

                $(LISTE_DEROULANTE_ENGAGEMENT).select2({
                    language: "fr",
                    placeholder: "",
                    allowClear: true,
                    minimumResultsForSearch: -1,
                    data: donnees
                });

                if ($(LISTE_DEROULANTE_ENGAGEMENT).select2("data").length > 0) {
                    $(LISTE_DEROULANTE_ENGAGEMENT + ' option').eq(0).prop('selected', true).change();
                }
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirEngagementPratique");
            }
        });
    }

    // Permet de sélectionner le type de pratique par défaut
    function SelectionnerTypePratiqueDefaut() {

        var numeroSequenceEngagementSelectionner = $(LISTE_DEROULANTE_ENGAGEMENT).select2("val");

        if (numeroSequenceEngagementSelectionner !== null) {
            var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagementSelectionner);


            if (engagement.Description == DESCRIPTION_ABSENCE_AVIS_CONFORMITE ||
                (engagement.Description == DESCRIPTION_AVIS && (engagement.Territoire.Type == TYPE_TERRITOIRE_RLS || engagement.Territoire.Type == "" || engagement.Territoire.Type == null)))
            {
                $(LISTE_DEROULANTE_PRATIQUE).val(TYPE_PRATIQUE_INTRA).trigger("change");
            }
            else {
                $(LISTE_DEROULANTE_PRATIQUE).val(TYPE_PRARTIQUE_INTER).trigger("change");
            }
        }
       

    }

    // Permet d'afficher l'information de l'engagement sélectionné
    function AfficherInformationEngagementSelectioner() {

        $(ZONE_INFORMATION_ENGAGEMENT)[0].innerHTML = '';

        var numeroSequenceEngagementSelectionner = $(LISTE_DEROULANTE_ENGAGEMENT).select2("val");

        if (numeroSequenceEngagementSelectionner !== null) {
            var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagementSelectionner);
            var dateDebut = FormatterDate(FormatterJsonDate(engagement.Periode.DateDebut));
            var dateFin = "- - - -";

            if (engagement.Periode.DateFin !== null) {
                dateFin = FormatterDate(FormatterJsonDate(engagement.Periode.DateFin));
            }

            var information = engagement.Description;

            if (engagement.Description == DESCRIPTION_DEROGATION || engagement.Description == DESCRIPTION_AUTORISATION) {
                ///<remarks>
                ///prise en compte de la demande 26 : Lors de la sélection du type d'engagement, le libellé "IVN" doit être remplacé par "Dérogation - Instance à vocation nationale" 
                ///</remarks>
                if (engagement.Type == "IVN")
                {
                    information += " - " + DESCRIPTION_DEROGATION_IVN;
                }
                else{
                        information += " - " + engagement.Type ;
                    }
            }
            else if (engagement.Description == DESCRIPTION_AVIS) {
                information += " - " + engagement.Territoire.Nom;
            }
            ///<remarks>
            ///prise en compte de la demande 26 : La notion "Absence d'avis" doit être remplacée par "Absence d'avis de conformité" dans l'ensemble des panoramas.
            ///</remarks>
            else
            {
                information = DESCRIPTION_ABSENCE_AVIS_CONFORMITE
            }

            information += " - " + dateDebut + " au " + dateFin;

            $(ZONE_INFORMATION_ENGAGEMENT).append(information);
        }
    }

    // Permet d'obtenir les pratiques exclusives
    function ObtenirRepartitionPratique() {

        var anneeSelectionner = $(LISTE_DEROULANTE_ANNEE).select2("val");
        var numeroSequenceEngagement = $(LISTE_DEROULANTE_ENGAGEMENT).select2("val");
  
        $('#ZoneMessage').css('display', 'none');
    
        if (numeroSequenceEngagement !== null) {
            var engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagement);
            var periode = RAMQ.Web.PLC2.DefinirPeriodePREM(engagement, anneeSelectionner);

            $.ajax({
                type: 'POST',
                url: controlleurPLC2.ObtenirRepartitionPratique,
                data: {
                    dateDebut: RAMQ.Web.PLC2.FormatDate(periode.DateDebut),
                    dateFin: RAMQ.Web.PLC2.FormatDate(periode.DateFin),
                    codeRSS: engagement.CodeRegion
                },
                success: function (extrant) {
                    $(ZONE_TABLEAU_REPARTITION)[0].innerHTML = '';
                    ConstruireTableau(anneeSelectionner, numeroSequenceEngagement, extrant);
                },
                error: function (err) {
                    ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirRepartitionPratique");
                }
            });
        }
    }

    // Permet de construire le tableau
    function ConstruireTableau(annee, numeroSequenceEngagement, calculFacturation) {

        var tableauInter = "";
        var tableauIntra = "";
        var pratiqueSelectionner = $(LISTE_DEROULANTE_PRATIQUE).select2("val");

        //if (pratiqueSelectionner == TYPE_PRATIQUE_INTRA) {
            if (annee >=2016 && pratiqueSelectionner == TYPE_PRATIQUE_INTRA) {
            tableauIntra = ConstruireTableauIntraregionnal(annee, numeroSequenceEngagement, calculFacturation);
            $(ZONE_TABLEAU_REPARTITION).append(tableauIntra);
            RemplirDonneesTableauIntra(annee, calculFacturation.JourneesFactTerritoire);
            $(ZONE_TABLEAU_REPARTITION).append("<span class='glyphicon glyphicon-exclamation-sign'/> " + "<i>Les jours admissibles peuvent comporter des jours fusionnés pour une même journée.</i>");
        }
        else {
            tableauInter = ConstruireTableauInterregionnal(annee, numeroSequenceEngagement, calculFacturation.JourneesFactRSS);
            $(ZONE_TABLEAU_REPARTITION).append(tableauInter);
            RemplirDonneesTableauInter(annee, calculFacturation.JourneesFactRSS);
        }
            
        
        // Permet de faire afficher 1 ranger de mois à la fois
        $('.collapse').on('show.bs.collapse', function () {
            $(this).closest("table")
                .find(".collapse.in")
                .not(this)
                .collapse('toggle')
        })
    }

    // Permet de faire la construction du tableau interrégionale
    function ConstruireTableauInterregionnal(annee, numeroSequenceEngagement, JourneeFacturerRSS) {

        var RssEnCours = "";
        var enteteTable = "";
        var corpsTable = "";
        var piedPageTable = "";
        var valeur = "";
        var engagement = "";
        var classeCollapse = "";
        var incrementeurClasseCollapse = 0;
        var valeurTotal;
        var classeCouleurRangee = "";
        var typeJour = "";

        if (numeroSequenceEngagement !== null) {
            engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagement);
        }

        if (JourneeFacturerRSS !== null) {

            enteteTable =
                "<table class='table table-striped table-hover' id='TableauInter'>" +
                "    <thead>" +
                "       <th></th>" +
                "       <th>Total des jours admissibles</th>" +
                "       <th>Proportion des jours admissibles</th>" +
                "   </thead>";


            corpsTable = "<tbody>";

            if (engagement.Description == DESCRIPTION_AVIS) {

                valeurTotal = RAMQ.Web.PLC2.ObtenirValeurListeJourneesFacturerRSS(engagement.CodeRegion, TYPE_JOUR_DEPANNAGE_LOC, null, null);

                if (valeurTotal.RSS == null) {
                    incrementeurClasseCollapse += 1;
                    classeCollapse = "collapsed" + incrementeurClasseCollapse;
                    classeCouleurRangee = "class='rangee-bleu'";

                    corpsTable +=
                        "   <tr " + classeCouleurRangee + " data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                        "       <th class='row-header'>" + RAMQ.Web.PLC2.ObtenirNomRSS(engagement.CodeRegion) + " - " + engagement.CodeRegion + "</th>" +
                        "       <td class='textmilieu'>0</td>" +
                        "       <td class='textmilieu'>0%</td>" +
                        "   </tr>";

                    corpsTable += DefinirMoisRSS(annee, engagement.CodeRegion, engagement, TYPE_JOUR_AUTRE, classeCollapse, classeCouleurRangee);
                }
                typeJour = TYPE_JOUR_DEPANNAGE_LOC;
            }
            else if (engagement.Description == DESCRIPTION_DEROGATION) {
                typeJour = TYPE_JOUR_TOTAL_DEROGATION;
            }
            else {
                typeJour = TYPE_JOUR_DEPANNAGE_LOC;
            }
            

            for (var i = 0; i < JourneeFacturerRSS.length; i++) {

                // Vérifie si le RSS en cours est différent du précédent
                if (RssEnCours !== JourneeFacturerRSS[i].RSS) {

                    if (JourneeFacturerRSS[i].RSS !== null) {

                        var rss = JourneeFacturerRSS[i].RSS;

                        valeurTotal = RAMQ.Web.PLC2.ObtenirValeurListeJourneesFacturerRSS(rss, typeJour, null, null);

                        if ((rss == engagement.CodeRegion && valeurTotal.NombreJours == 0) ||
                            (valeurTotal.NombreJours !== 0)) {
                            incrementeurClasseCollapse += 1;
                            classeCollapse = "collapsed" + incrementeurClasseCollapse;


                            if (engagement.Territoire.Type == TYPE_TERRITOIRE_RSS && engagement.CodeRegion == JourneeFacturerRSS[i].RSS) {
                                classeCouleurRangee = "class='rangee-bleu'";

                                corpsTable +=
                                    "   <tr " + classeCouleurRangee + " data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                    "       <th class='row-header'>" + RAMQ.Web.PLC2.ObtenirNomRSS(JourneeFacturerRSS[i].RSS) + " - " + JourneeFacturerRSS[i].RSS + "</th>" +
                                    "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                    "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                                    "   </tr>";
                            }
                            else if (engagement.Territoire.Type == TYPE_TERRITOIRE_RLS || engagement.Territoire.Type == TYPE_TERRITIORE_TERRITOIRE) {
                                classeCouleurRangee = "";
                                corpsTable +=
                                   "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                   "       <th class='row-header'>" + RAMQ.Web.PLC2.ObtenirNomRSS(JourneeFacturerRSS[i].RSS) + " - " + JourneeFacturerRSS[i].RSS + "</th>" +
                                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                    "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                                   "   </tr>";
                            }
                            else if (engagement.Description == DESCRIPTION_DEROGATION || engagement.Description == DESCRIPTION_ABSENCE_AVIS) {
                                classeCouleurRangee = "";
                                corpsTable +=
                                   "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                   "       <th class='row-header'>" + RAMQ.Web.PLC2.ObtenirNomRSS(JourneeFacturerRSS[i].RSS) + " - " + JourneeFacturerRSS[i].RSS + "</th>" +
                                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                                   "   </tr>";
                            }
                            else {
                                classeCouleurRangee = "";
                                corpsTable +=
                                   "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                   "       <th class='row-header'>" + RAMQ.Web.PLC2.ObtenirNomRSS(JourneeFacturerRSS[i].RSS) + " - " + JourneeFacturerRSS[i].RSS + "</th>" +
                                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                   "       <td class='textmilieu'></td>" +
                                   "   </tr>";
                            }

                           

                            corpsTable += DefinirMoisRSS(annee, rss, engagement, TYPE_JOUR_DEPANNAGE_LOC, classeCollapse, classeCouleurRangee);
                        }

                        RssEnCours = JourneeFacturerRSS[i].RSS;
                    }
                    else {
                        RssEnCours = "";
                    }
                }

            }

            if (engagement.Description == DESCRIPTION_DEROGATION) {
                typeJour = TYPE_JOUR_HORS_QUEBEC_DEROGATION;
            }
            else {
                typeJour = TYPE_JOUR_HORS_QUEBEC;
            }

            valeurTotal = RAMQ.Web.PLC2.ObtenirValeurListeJourneesFacturerRSS("", typeJour, null, null);

            if (valeurTotal.NombreJours !== 0) {

                incrementeurClasseCollapse += 1;
                classeCollapse = "collapsed" + incrementeurClasseCollapse;


                if (engagement.Territoire.Type == TYPE_TERRITOIRE_RSS) {

                    corpsTable +=
                        "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                        "       <th class='row-header'>Hors-Québec</th>" +
                        "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                        "       <td class='textmilieu'></td>" +
                        "   </tr>";
                }
                else {

                    corpsTable +=
                        "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                        "       <th class='row-header'>Hors-Québec</th>" +
                        "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                        "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                        "   </tr>";
                }


                corpsTable += DefinirMoisRSS(annee, "", engagement, TYPE_JOUR_HORS_QUEBEC, classeCollapse, "");
            } 

            if (engagement.Description == DESCRIPTION_DEROGATION) {
                valeurTotal = RAMQ.Web.PLC2.ObtenirValeurListeJourneesFacturerRSS("", TYPE_JOUR_TOTAL_DEROGATION, null, null);
            }
            else {
                valeurTotal = RAMQ.Web.PLC2.ObtenirValeurListeJourneesFacturerRSS("", TYPE_JOUR_TOTAL, null, null);
            }

            piedPageTable =
                "<tfoot>" +
                "   <tr>" +
                "       <td></td>" +
                "       <td></td>" +
                "       <td></td>" +
                "   </tr>" +
                "   <tr>" +
                "       <th class='row-header'>Total des journées admissibles</th>" +
                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                "   </tr>" +
                "</tfoot>";

            return (enteteTable + corpsTable + piedPageTable);

        } else {
            $('#ZoneMessage').css('display', 'none');
        }
    }

    // Permet de faire la construction du tableau intra-régional
    function ConstruireTableauIntraregionnal(annee, numeroSequenceEngagement, calculFacturation) {

        var journeesFacturerTerritoire = calculFacturation.JourneesFactTerritoire;
        var enteteTable = "";
        var corpsTable = "";
        var piedPageTable = "";
        var valeurTotal;
        var codeLieu = "";
        var typeLieu = "";
        var numeroSequenceRegroupement = "";
        var incrementeurClasseCollapse = 0;
        var typeLieuEnCours = "";
        var codeLieuEnCours = "";
        var numeroSequenceRegroupementEnCours = "";
        var codeRss = "";
        var classeCouleurRangee = "";
        var typeTerritoire = "";
        var nomTerritoire = "";
        var typeJour = "";

        if (numeroSequenceEngagement !== null) {
            engagement = RAMQ.Web.PLC2.ObtenirInformationEngagement(numeroSequenceEngagement);
            typeTerritoire = engagement.Territoire.Type;
        }

        if (journeesFacturerTerritoire !== null) {

            enteteTable =
                "<table class='table table-striped table-hover' id='TableauIntra'>" +
                "    <thead>" +
                "       <th></th>" +
                "       <th>Total des jours admissibles</th>" +
                "       <th>Proportion des jours admissibles</th>" +
                "   </thead>";


            corpsTable = "<tbody>";
        }

        if (engagement.Description == DESCRIPTION_AVIS && engagement.Territoire.Type !== TYPE_TERRITOIRE_RSS) {

            valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire(engagement.Territoire.CodeLieuGeographique,
                                                                       null,
                                                                       engagement.Territoire.NumeroSequentielRegroupement,
                                                                       TYPE_JOUR_DEPANNAGE_LOC,
                                                                       null,
                                                                       null);

            if (valeurTotal.CodeRSS == null) {
                incrementeurClasseCollapse += 1;
                classeCollapse = "collapsed" + incrementeurClasseCollapse;
                classeCouleurRangee = "class='rangee-bleu'";

                var informationTerritoire = {
                    NumeroSequentiel: engagement.Territoire.NumeroSequentielRegroupement,
                    Type: null,
                    Code: engagement.Territoire.CodeLieuGeographique,
                    DateDebutPratique : null
                };

                nomTerritoire = ObtenirNomTerritoire(informationTerritoire)

                corpsTable +=   "   <tr " +classeCouleurRangee + " data-toggle='collapse' data-target=" + "." +classeCollapse + ">" +
                                "       <th class='row-header'>" + nomTerritoire + " - " + engagement.Territoire.CodeLieuGeographique + "</th>" +
                                "       <td class='textmilieu'>0</td>" +
                                "       <td class='textmilieu'>0%</td>" +
                                "   </tr>";

                corpsTable += DefinirMoisTerritoire(annee,
                                                    engagement.Territoire.CodeLieuGeographique,
                                                    engagement.Territoire.NumeroSequentielRegroupement,
                                                    engagement,
                                                    TYPE_JOUR_AUTRE,
                                                    classeCollapse,
                                                    classeCouleurRangee);
            }

        }

        for (var i = 0; i < journeesFacturerTerritoire.length; i++) {

            codeLieu = journeesFacturerTerritoire[i].CodeLieuGeographique;
            typeLieu = journeesFacturerTerritoire[i].TypeLieuGeographique;
            numeroSequenceRegroupement = journeesFacturerTerritoire[i].NumeroSeqRegrAdmnLGEO;
            codeRss = journeesFacturerTerritoire[i].CodeRSS;


            if (typeLieuEnCours !== typeLieu || codeLieuEnCours !== codeLieu || numeroSequenceRegroupementEnCours !== numeroSequenceRegroupement) {

                if (codeLieu !== null || typeLieu !== null || numeroSequenceRegroupement !== null) {

                    incrementeurClasseCollapse += 1;
                    classeCollapse = "collapsed" + incrementeurClasseCollapse;
                  
                    var informationTerritoire = {
                        NumeroSequentiel: numeroSequenceRegroupement,
                        Type: typeLieu,
                        Code: codeLieu,
                        DateDebutPratique: null
                    };


                    if (engagement.Description == DESCRIPTION_DEROGATION) {
                        typeJour = TYPE_JOUR_TOTAL_DEROGATION;
                    }
                    else {
                        typeJour = TYPE_JOUR_DEPANNAGE_LOC;
                    }

                    valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire(codeLieu,
                                                                               typeLieu,
                                                                               numeroSequenceRegroupement,
                                                                               typeJour,
                                                                               null,
                                                                               null);

                    if ((((typeTerritoire == TYPE_TERRITOIRE_REGROUPEMENT ||
                            typeTerritoire == TYPE_TERRITIORE_TERRITOIRE ||
                            typeTerritoire == TYPE_TERRITOIRE_RLS) &&
                            nomTerritoire == engagement.Territoire.Nom) ||
                            (typeTerritoire == TYPE_TERRITOIRE_RSS && engagement.CodeRegion == codeRss) && valeurTotal.NombreJours == 0) ||
                        valeurTotal.NombreJours !== 0) {

                        nomTerritoire = ObtenirNomTerritoire(informationTerritoire)


                        if (((typeTerritoire == TYPE_TERRITOIRE_REGROUPEMENT ||
                            typeTerritoire == TYPE_TERRITIORE_TERRITOIRE ||
                            typeTerritoire == TYPE_TERRITOIRE_RLS) &&
                            nomTerritoire == engagement.Territoire.Nom) ||
                            (typeTerritoire == TYPE_TERRITOIRE_RSS && engagement.CodeRegion == codeRss)) {
                            classeCouleurRangee = "class='rangee-bleu'";
                            corpsTable +=
                                "   <tr " + classeCouleurRangee + " data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                "       <th class='row-header'>" + nomTerritoire + " - " + codeRss + "</th>" +
                                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                                "   </tr>";
                        }
                        else if (engagement.Description == DESCRIPTION_DEROGATION || engagement.Description == DESCRIPTION_ABSENCE_AVIS || typeTerritoire == TYPE_TERRITOIRE_RSS) {
                            classeCouleurRangee = "";
                            corpsTable +=
                                "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                                "       <th class='row-header'>" + nomTerritoire + " - " + codeRss + "</th>" +
                                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                                "   </tr>";
                        }
                        else {
                            classeCouleurRangee = "";
                            corpsTable +=
                                "   <tr data-toggle='collapse' data-target=" + "." +classeCollapse + ">" +
                                "       <th class='row-header'>" + nomTerritoire + " - " + codeRss + "</th>" +
                                "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                                "       <td class='textmilieu'></td>" +
                                "   </tr>";
                        }

                        corpsTable += DefinirMoisTerritoire(annee, codeLieu, numeroSequenceRegroupement, engagement, TYPE_JOUR_DEPANNAGE_LOC, classeCollapse, classeCouleurRangee);

                        typeLieuEnCours = typeLieu;
                        codeLieuEnCours = codeLieu;
                        numeroSequenceRegroupementEnCours = numeroSequenceRegroupement;
                    }
                    
                }
                else {
                    typeLieuEnCours = "";
                    codeLieuEnCours = "";
                    numeroSequenceRegroupementEnCours = "";
                }
            }

            
        }


        // Section Hors-Québec

        if (engagement.Description == DESCRIPTION_DEROGATION) {
            typeJour = TYPE_JOUR_HORS_QUEBEC_DEROGATION;
        }
        else {
            typeJour = TYPE_JOUR_HORS_QUEBEC;
        }
       
        valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire("", "", "", typeJour, null, null);

        if (valeurTotal.NombreJours !== 0) {
            incrementeurClasseCollapse += 1;
            classeCollapse = "collapsed" + incrementeurClasseCollapse;

            if (engagement.Description == DESCRIPTION_DEROGATION || engagement.Description == DESCRIPTION_ABSENCE_AVIS || typeTerritoire == TYPE_TERRITOIRE_RSS) {
                corpsTable +=
                   "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                   "       <th class='row-header'>Hors-Québec</th>" +
                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                   "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                   "   </tr>";
            }
            else {
                corpsTable +=
           "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
           "       <th class='row-header'>Hors-Québec</th>" +
           "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
           "       <td class='textmilieu'></td>" +
           "   </tr>";
            }

           

            corpsTable += DefinirMoisTerritoire(annee, codeLieu, numeroSequenceRegroupement, engagement, TYPE_JOUR_HORS_QUEBEC, classeCollapse, "");

        }

        //Section Localité

        if (engagement.Description == DESCRIPTION_DEROGATION) {
            typeJour = TYPE_JOUR_LOCALITE_DEROGATION;
        }
        else {
            typeJour = TYPE_JOUR_LOCALITE;
        }

        valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire("", "", "", typeJour, null, null);

        if (valeurTotal.NombreJours !== 0) {
            incrementeurClasseCollapse += 1;
            classeCollapse = "collapsed" + incrementeurClasseCollapse;

            if (engagement.Description == DESCRIPTION_DEROGATION || engagement.Description == DESCRIPTION_ABSENCE_AVIS || typeTerritoire == TYPE_TERRITOIRE_RSS) {
                corpsTable +=
                     "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                     "       <th class='row-header'>Facturation avec code de localité</th>" +
                     "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                     "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
                     "   </tr>";
            }
            else {
                corpsTable +=
                     "   <tr data-toggle='collapse' data-target=" + "." + classeCollapse + ">" +
                     "       <th class='row-header'>Facturation avec code de localité</th>" +
                     "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
                     "       <td class='textmilieu'></td>" +
                     "   </tr>";
            }
          
        
            corpsTable += DefinirMoisTerritoire(annee, codeLieu, numeroSequenceRegroupement, engagement, TYPE_JOUR_LOCALITE, classeCollapse, "");
        }
       


        // Section pied de page
        if (engagement.Description == DESCRIPTION_DEROGATION) {
            valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire("", "", "", TYPE_JOUR_TOTAL_DEROGATION, null, null);
        }
        else {
            valeurTotal = ObtenirValeurListeJourneesFacturerTerritoire("", "", "", TYPE_JOUR_TOTAL, null, null);
        }

        piedPageTable =
            "<tfoot>" +
            "   <tr>" +
            "       <td></td>" +
            "       <td></td>" +
            "       <td></td>" +
            "   </tr>" +
            "   <tr>" +
            "       <th class='row-header'>Total des journées admissibles</th>" +
            "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.NombreJours) + "</td>" +
            "       <td class='textmilieu'>" + ArrondirNombre(valeurTotal.Pourcentage) + "%</td>" +
            "   </tr>" +
            "</tfoot>";

        return (enteteTable + corpsTable + piedPageTable);

    }

    // Permet de définir les mois pour les RSS
    function DefinirMoisRSS(annee, rss, engagement, typeJour, classeCollapse, classeCouleurRangee) {

        var periodeMois = RAMQ.Web.PLC2.DefinirPeriodeMois(engagement, annee);
        var corpsTableau = "";
        var idRanger = "";
        var estSuspendu = false;
        presenceSuspension = false;

        for (var i = periodeMois.MoisDebut; i <= periodeMois.MoisFin ; i++) {

            var entiteMois = $.grep(moisPrem, function (e) {
                return e.NumeroMoisPREM == i;
            });

            if (typeJour == TYPE_JOUR_HORS_QUEBEC || typeJour == TYPE_JOUR_LOCALITE) {
                idRanger = entiteMois[0].Mois + typeJour;
            }
            else if (typeJour == TYPE_JOUR_DEPANNAGE_LOC) {
                idRanger = entiteMois[0].Mois + rss;
            }
            else if (typeJour == TYPE_JOUR_AUTRE) {
                idRanger = entiteMois[0].Mois + TYPE_JOUR_AUTRE;
            }

            estSuspendu = VerifierstatutSuspendu(engagement, i, annee);

            if (estSuspendu) {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + " " + "sous-rangee-jaune" + "'" + " id=" + idRanger + ">";
                presenceSuspension = true;
            }
            
            else if (classeCouleurRangee !== "" && (i % 2) !== 0) {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + " " + "sous-rangee-bleu" + "'" + " id=" + idRanger + ">";
            }
            else {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + "'" +  " id=" + idRanger + ">";
            }


            if (entiteMois[0].Mois == "Janvier" || entiteMois[0].Mois == "Fevrier") {
                corpsTableau += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + (parseInt(annee) + 1).toString() + "</td>";
            }
            else {
                corpsTableau += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + annee + "</td>";
            }

            if (typeJour == "Autre") {
                corpsTableau += "<td class='textmilieu'>0</td>" + "<td class='textmilieu'></td>";
            }                      

            corpsTableau += "</tr>";

        }

        if (presenceSuspension) {
            $('#ZoneMessage').html('<span class="glyphicon glyphicon-exclamation-sign"/> ' + RetourneMessageErreur('148642')).css('display', 'block');
        } else {
            $('#ZoneMessage').css('display', 'none');
        }
        return corpsTableau;
    }

    // Permet de définir les mois pour les territoire
    function DefinirMoisTerritoire(annee, codeLieu, numeroSequenceRegroupement, engagement, typeJour, classeCollapse, classeCouleurRangee) {
        var periodeMois = RAMQ.Web.PLC2.DefinirPeriodeMois(engagement, annee);
        var corpsTableau = "";
        var idRanger = "";
        var estSuspendu = false;
        presenceSuspension = false;


        for (var i = periodeMois.MoisDebut; i <= periodeMois.MoisFin ; i++) {

            var entiteMois = $.grep(moisPrem, function (e) {
                return e.NumeroMoisPREM == i;
            });

            if (typeJour == TYPE_JOUR_HORS_QUEBEC || typeJour == TYPE_JOUR_LOCALITE) {
                idRanger = entiteMois[0].Mois + typeJour;
            }
            else if (typeJour == TYPE_JOUR_DEPANNAGE_LOC && numeroSequenceRegroupement !== null) {
                idRanger = entiteMois[0].Mois + numeroSequenceRegroupement;
            }
            else if (typeJour == TYPE_JOUR_DEPANNAGE_LOC && codeLieu !== null) {
                idRanger = entiteMois[0].Mois + codeLieu;
            }
            else if (typeJour == TYPE_JOUR_AUTRE) {
                idRanger = entiteMois[0].Mois + TYPE_JOUR_AUTRE;
            }

            estSuspendu = VerifierstatutSuspendu(engagement, i, annee);

            if (estSuspendu) {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + " " + "sous-rangee-jaune" + "'" + " id=" + idRanger + ">";
                presenceSuspension = true;
            }
            else if (classeCouleurRangee !== "" && (i % 2) !== 0) {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + " " + "sous-rangee-bleu" + "'" + " id=" + idRanger + ">";
            }
            else {
                corpsTableau += "<tr class=" + "'" + "collapse " + classeCollapse + "'" + " id=" + idRanger + ">";
            }


            if (entiteMois[0].Mois == "Janvier" || entiteMois[0].Mois == "Fevrier") {
                corpsTableau += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + (parseInt(annee) + 1).toString() + "</td>";
            }
            else {
                corpsTableau += "<td>" + RAMQ.Web.PLC2.ObtenirMoisAvecAccent(entiteMois[0].Mois) + " " + annee + "</td>";
            }

            if (typeJour == "Autre") {
                corpsTableau += "<td class='textmilieu'>0</td>" + "<td class='textmilieu'></td>";
            }


            corpsTableau += "</tr>";

        }

        if (presenceSuspension) {
            $('#ZoneMessage').html('<span class="glyphicon glyphicon-exclamation-sign"/> '+RetourneMessageErreur('148642')).css('display', 'block');
        } else {
            $('#ZoneMessage').css('display', 'none');
        }
        return corpsTableau;

    }


    // Permet de remplir le tableau interrégional de données
    function RemplirDonneesTableauInter(annee, journeeFacturerRSS) {

        var valeur;
        var chiffreMois;
        var mois;
        var idMois
        var anneeTemporaire;

        for (var i = 0; i < journeeFacturerRSS.length; i++) {

            chiffreMois = journeeFacturerRSS[i].Mois;
            valeur = "";
            
            if (chiffreMois !== null) {
                mois = RAMQ.Web.PLC2.ObtenirMoisSelonChiffre(chiffreMois)
                idMois = "";

                if (mois == "Janvier" || mois == "Fevrier") {
                    anneeTemporaire = parseInt(annee) + 1;
                }
                else {
                    anneeTemporaire = annee;
                }

                if (journeeFacturerRSS[i].TypeJours == TYPE_JOUR_DEPANNAGE_LOC && journeeFacturerRSS[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeeFacturerRSS[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeeFacturerRSS[i].Pourcentage)
                    }
                }
                else if (journeeFacturerRSS[i].TypeJours == TYPE_JOUR_HORS_QUEBEC && journeeFacturerRSS[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeeFacturerRSS[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeeFacturerRSS[i].Pourcentage)
                    }
                }
                else if (journeeFacturerRSS[i].TypeJours == TYPE_JOUR_TOTAL && journeeFacturerRSS[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeeFacturerRSS[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeeFacturerRSS[i].Pourcentage)
                    }
                }




                if (journeeFacturerRSS[i].TypeJours == TYPE_JOUR_HORS_QUEBEC || journeeFacturerRSS[i].TypeJours == TYPE_JOUR_LOCALITE) {
                    idMois = mois + journeeFacturerRSS[i].TypeJours;
                }
                else if (journeeFacturerRSS[i].TypeJours == TYPE_JOUR_DEPANNAGE_LOC && journeeFacturerRSS[i].RSS !== null) {
                    idMois = mois + journeeFacturerRSS[i].RSS
                }

                if (valeur !== "") {
                    $("#" + idMois).append("<td class='textmilieu'>" + valeur.NombreJours + "</td>");
                    $("#" + idMois).append("<td class='textmilieu'></td>");
                }

            }
        }
    }

    // Permet de remplir le tableau intra-régional de données
    function RemplirDonneesTableauIntra(annee, journeesFactTerritoire) {

        var chiffreMois;
        var codeLieuGeo = "";
        var typeLieuGeo = "";
        var numSeqRegroupementLieuGeo;
        var mois = "";
        var idMois = "";
        var valeur;
        var anneeTemporaire;

        for (var i = 0; i < journeesFactTerritoire.length; i++) {
            chiffreMois = journeesFactTerritoire[i].Mois;
            valeur = "";
            
            if (chiffreMois !== null) {
                mois = RAMQ.Web.PLC2.ObtenirMoisSelonChiffre(chiffreMois);
                idMois = "";
                

                if (mois == "Janvier" || mois == "Fevrier") {
                    anneeTemporaire = parseInt(annee) + 1;
                }
                else {
                    anneeTemporaire = annee;
                }

                codeLieu = journeesFactTerritoire[i].CodeLieuGeographique;
                typeLieu = journeesFactTerritoire[i].TypeLieuGeographique;
                numeroSequenceRegroupement = journeesFactTerritoire[i].NumeroSeqRegrAdmnLGEO;
               

                if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_DEPANNAGE_LOC && journeesFactTerritoire[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeesFactTerritoire[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeesFactTerritoire[i].Pourcentage)
                    }
                }
                else if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_HORS_QUEBEC && journeesFactTerritoire[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeesFactTerritoire[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeesFactTerritoire[i].Pourcentage)
                    }
                }
                else if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_LOCALITE && journeesFactTerritoire[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeesFactTerritoire[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeesFactTerritoire[i].Pourcentage)
                    }
                }
                else if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_TOTAL && journeesFactTerritoire[i].Annee == anneeTemporaire) {
                    valeur = {
                        NombreJours: ArrondirNombre(journeesFactTerritoire[i].NombreJours),
                        Pourcentage: ArrondirNombre(journeesFactTerritoire[i].Pourcentage)
                    }
                }


                if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_HORS_QUEBEC || journeesFactTerritoire[i].TypeJours == TYPE_JOUR_LOCALITE) {
                    idMois = mois + journeesFactTerritoire[i].TypeJours;
                }
                else if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_DEPANNAGE_LOC && codeLieu !== null) {
                    idMois = mois + codeLieu
                }
                else if (journeesFactTerritoire[i].TypeJours == TYPE_JOUR_DEPANNAGE_LOC && numeroSequenceRegroupement !== null) {
                    idMois = mois + numeroSequenceRegroupement
                }

                if (valeur !== "") {

                    $("#" + idMois).append("<td class='textmilieu'>" + valeur.NombreJours + "</td>");
                    $("#" +idMois).append("<td class='textmilieu'></td>");
                }

            }
        }
    }

    // Permet d'obtenir le nom du territoire
    function ObtenirNomTerritoire(informationTerritoire) {
        var nomTerritoire = "";
        $.ajax({
            cache: false,
            type: 'POST',
            url: controlleurCommun.ObtenirNomTerritoireSelonAvisConformite,
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

    // Permet d'obtenir la valeur dans une liste de journées facturé par territoire
    function ObtenirValeurListeJourneesFacturerTerritoire(codeLieuGeo, typeLieuGeo, numSeqRegroupementLieuGeo, typeJour, annee, mois) {

        $.ajax({
            type: 'POST',
            url: controlleurPLC2.ObtenirValeurListeJourneesFacturerTerritoire,
            data: {
                NumeroSequenceRegroupementLieuGeo: numSeqRegroupementLieuGeo,
                TypeLieuGeo: typeLieuGeo,
                CodeLieuGeo: codeLieuGeo,
                TypeJour: typeJour,
                Annee: annee,
                Mois: mois
            },
            async: false,
            success: function (obj) {
                if (obj !== null) {
                    valeur = obj;
                }
                else {
                    valeur = "";
                }

            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX dans la fonction JavaScript ObtenirValeurListeJourneesFacturerRSS");
            }
        });
        return valeur;
    }

    // Permet d'obtenir la liste des statut suspendu pour un engagement;
    function ObtenirStatutSuspendus(engagement) {

        var statutSuspendus = [];

        for (var i = 0; i < engagement.Historiques.length; i++) {

            if (engagement.Historiques[i].Statut == STATUT_SUSPENDU) {
                statutSuspendus.push(engagement.Historiques[i]);
            }

        }
        
        return statutSuspendus;
       
    }

    // Permet de vérifier s'il y a un statut suspendu pour un mois
    function VerifierstatutSuspendu(engagement, moisEnCours, annee) {

        var dateDebutStatut;
        var anneeDebutStatut;
        var moisDebutStatut;
        var dateFinStatut;
        var anneeFinStatut;
        var moisFinStatut;
        var statutSuspendus = ObtenirStatutSuspendus(engagement);
        var estSuspendu = false;

        if (statutSuspendus.length > 0) {

            for (var j = 0; j < statutSuspendus.length; j++) {

                dateDebutStatut = FormatterDate(FormatterJsonDate(statutSuspendus[j].Periode.DateDebut));
                anneeDebutStatut = dateDebutStatut.substring(0, 4);
                moisDebutStatut = dateDebutStatut.substring(5, 7);


                dateFinStatut = FormatterDate(FormatterJsonDate(statutSuspendus[j].Periode.DateFin));
                anneeFinStatut = dateFinStatut.substring(0, 4);
                moisFinStatut = dateFinStatut.substring(5, 7);

                if (anneeDebutStatut <= annee && annee <= anneeFinStatut) {
                    var numeroMoisDebutPrem = $.grep(moisPrem, function (e) {
                        return e.NumeroMois == parseInt(moisDebutStatut);
                    });

                    var numeroMoisFinPrem = $.grep(moisPrem, function (e) {
                        return e.NumeroMois == parseInt(moisFinStatut);
                    });


                    if ((numeroMoisDebutPrem[0].NumeroMoisPREM <= moisEnCours && moisEnCours <= numeroMoisFinPrem[0].NumeroMoisPREM) && anneeDebutStatut == annee) {
                        estSuspendu = true;
                    }
                }
            }

        }

        return estSuspendu;
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

    if ("undefined" == typeof (window.RAMQ.Web.PLC2_RepartitionPratique))
        window.RAMQ.Web.PLC2_RepartitionPratique = {
            "ObtenirInformationRepartitionPratique": ObtenirInformationRepartitionPratique
        };

})(window, $);