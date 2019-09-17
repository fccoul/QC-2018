(function (window, $) 
{
    $(document).ready(function ()
    {
        InitialiseDatepicker();
        EnregistrerEvenement();
    });

    //Fonction permettant d'enregistrer tous les événements de la page.
    function EnregistrerEvenement()
    {

    }

    function InitialiseDatepicker()
    {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            language: 'fr',
            orientation: "bottom auto"
        });
    }

})(window, $);