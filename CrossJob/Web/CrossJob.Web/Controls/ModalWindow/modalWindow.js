(function () {
    document.addEventListener("DOMContentLoaded", function () {
        var $input = $($("#modalWindowControlHolder input")[0]);

        if ($input.val() === "1") {
            $("#modalWindowButtonOpen").click();
            $input.val("0");
        }
    });
}());