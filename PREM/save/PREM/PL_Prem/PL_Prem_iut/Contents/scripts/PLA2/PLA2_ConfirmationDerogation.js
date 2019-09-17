(function (window, $) {

    $(document).ready(function () {
        AfficherBouton();

        if ($("#MessageFermetureEngagement").val() !== "") {
            $("#ZoneMessageEngagementFermer").css("display", "block");
        }
        else {
            $("#ZoneMessageEngagementFermer").css("display", "none");
        }
    });

    // Fonction permettant d'afficher le bon bouton de nouvelle action possible.
    function AfficherBouton() {

        var estModeAnnulation = $("#EstModeAnnulation").val();

        if (estModeAnnulation == "True")
        {
            $("#annulerDerogation").attr('class', 'btn btn-primary btn-block').css("display", "block");
            $("#transmettreDerogation").attr('class', 'btn btn-primary').css("display", "none");
        }
        else
        {
            $("#annulerDerogation").attr('class', 'btn btn-primary').css("display", "none");
            $("#transmettreDerogation").attr('class', 'btn btn-primary btn-block').css("display", "block");
        }
    }

})(window, $);