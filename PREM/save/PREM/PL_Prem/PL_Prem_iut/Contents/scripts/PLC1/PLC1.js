(function (window, $) {

    // ### Initialisation des événements ###
    $(document).ready(function () {
        $("#BtnImprimer").click(function () {
            window.print();
        });
    })



    // ### Interfaces ###
    if ("undefined" == typeof (window.RAMQ))
        window.RAMQ = new Object();

    if ("undefined" == typeof (window.RAMQ.Web))
        window.RAMQ.Web = new Object();

    if ("undefined" == typeof (window.RAMQ.Web.PLC1))
        window.RAMQ.Web.PLC1 = {};
})(window, $);