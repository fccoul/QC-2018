(function (window, $) {

    var divHistoriqueEngagement = $("#HistoriqueEngagementDiv");


    // Permet de charger les informations des engagements de pratique
    function ObtenirHistoriqueEngagement(numeroPratique) {

        $.ajax({
            url: divHistoriqueEngagement.data('request-url'),
            data: { NumeroPratique: numeroPratique },
            type: "GET",
            cache: false,
            success: function (html) {

               

                if (RAMQ.Web.PLC2.ValiderDroitDRMG() == "True") {
                    var medecinResponsabiliteDRMG = $(html).find("#MedecinResponsabiliteDRMG").val();

                    if (medecinResponsabiliteDRMG == "True") {
                        RAMQ.Web.PLC2.AjouterHtmlDiv(divHistoriqueEngagement, html);

                        RAMQ.Web.PLC2_RepartitionPratique.ObtenirInformationRepartitionPratique();
                    }
                    else if (medecinResponsabiliteDRMG == "False") {
                        var messageErreur = $(html).find("#MessageErreur").val();

                        $("#MessageInformation").html(messageErreur).css("display", "block");

                        RAMQ.Web.PLC2.InactiverOnglets();
                        RAMQ.Web.PLC2.CacherFenetreChargement();
                    }
                    else {
                        var messageErreur = "Un problème est survenu lors de la validation du DRMG";
                        $("#MessageInformation").html(messageErreur).css("display", "block");

                        RAMQ.Web.PLC2.InactiverOnglets();
                        RAMQ.Web.PLC2.CacherFenetreChargement();
                    }
                }
                else {
                    RAMQ.Web.PLC2.AjouterHtmlDiv(divHistoriqueEngagement, html);

                    RAMQ.Web.PLC2_RepartitionPratique.ObtenirInformationRepartitionPratique();
                }

                
                $('[data-toggle="tooltipStatus"]').tooltip();

                // ### Correctif de la zone de clics pour le toggle de l'historique ###
                $('.panel-heading').click(function (e) {

                    $($(this).find('a').attr('href')).collapse("toggle");

                });
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX du chargement de l'onglet Engagement de la pratique");
            }
        });
    }
  
   
    // ### Interfaces ###
    if ("undefined" == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ("undefined" == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ("undefined" == typeof (window.RAMQ.Web.PLC2_HistoriqueEngagement))
        window.RAMQ.Web.PLC2_HistoriqueEngagement = {
            "ObtenirHistoriqueEngagement": ObtenirHistoriqueEngagement
        };
})(window, $);




