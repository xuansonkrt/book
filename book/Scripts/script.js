$(document).ready(function () {
    //$("#SoLuong").spinner({
    //    min: 1,
    //    max: 100,
    //    step: 1
    //});


    $("#SoLuong").on("change", function () {
        var amount = $("#SoLuong").val();
        if (amount <= 0) {
            $("#SoLuong").val(1);
        }
    });
});