(function (window, $) {

    $(document).ready(function () {

        $(".select2dropdownlist").select2({
            language: "fr",
            placeholder: "",
            minimumResultsForSearch: -1
        });

        InitialiseDatepicker();

        if ($("#ModeAffichage").val() == "Modifier") {
            $("#DateDebut").prop('disabled', true);
            $(".datepicker").datepicker('remove');
        }
        else {
            $("#DateDebut").prop('disabled', false);
        }

        $("#DateFin").prop('disabled', false);
        $(".field-validation-error").text("");



        if (ValiderGroupeSupport()) {
            $("#BoutonGenerique").prop('disabled', true);
        }
        else {
            $("#BoutonGenerique").prop('disabled', false);
        }

    });

    function InitialiseDatepicker() {
        $(".datepicker").datepicker({
            format: 'yyyy-mm-dd',
            autoclose: true,
            language: 'fr',
            orientation: "bottom auto"
        });
    }

})(window, $);