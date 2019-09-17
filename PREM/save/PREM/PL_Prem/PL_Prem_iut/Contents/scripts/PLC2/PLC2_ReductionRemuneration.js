(function (window, $) {

    var divReductionRemuneration = $("#ReductionRemunerationDiv");


    // ### Initialisation des événements ###
    $(document).ready(function () {
    });


    // Permet de charger les informations de la réduction à la rémunération
    function ObtenirInformationReductionRemuneration() {

        $.ajax({
            url: divReductionRemuneration.data('request-url'),
            type: "GET",
            cache: false,
            success: function (html) {

                // TODO : Remettre l'appel lorsque la réduction à la rémunération sera à livrer
                //RAMQ.Web.PLC2.AjouterHtmlDiv(divReductionRemuneration, html);
            },
            error: function (err) {
                ErreurTechnique(err, "Erreur pendant un appel AJAX du chargement de l'onglet Réduction de la rémunération");
            }
        });

        RAMQ.Web.PLC2.CacherFenetreChargement();
    }


    // ### Interfaces ###
    if ("undefined" == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ("undefined" == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ("undefined" == typeof (window.RAMQ.Web.PLC2_ReductionRemuneration))
        window.RAMQ.Web.PLC2_ReductionRemuneration = {
            "ObtenirInformationReductionRemuneration": ObtenirInformationReductionRemuneration
        };

})(window, $);