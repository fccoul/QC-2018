(function (window, $) {

    var divDroitAcquis = $("#RegionPratiquePartielleRestreinteDiv");

    // ### Initialisation des événements ###
    $(document).ready(function () {
    });


    // Permet de charger les informations des droits acquis
    function ObtenirInformationRegionPratiquePartielleRestreinte() {
        $.ajax({
            url: divDroitAcquis.data('request-url'),
            type: "GET",
            cache: false,
            success: function (html) {

                RAMQ.Web.PLC2.AjouterHtmlDiv(divDroitAcquis, html);

                RAMQ.Web.PLC2_ReductionRemuneration.ObtenirInformationReductionRemuneration();
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX du chargement de l'onglet Droits Acquis");
            }
        });
    }


    // ### Interfaces ###
    if ("undefined" == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ("undefined" == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ("undefined" == typeof (window.RAMQ.Web.PLC2_RegionPratiquePartielleRestreinte))
        window.RAMQ.Web.PLC2_RegionPratiquePartielleRestreinte = {
            "ObtenirInformationRegionPratiquePartielleRestreinte": ObtenirInformationRegionPratiquePartielleRestreinte
        };

})(window, $);