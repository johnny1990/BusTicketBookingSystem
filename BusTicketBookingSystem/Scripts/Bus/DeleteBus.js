$(document).ready(function () {
    $("#btnDelete").click(function () {
        var BusId = $("#hidId");
        $.ajax({
            type: "POST",
            url: "/Buses/DeleteBus",
            data: '{id: ' + BusId.val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                window.location = 'https://localhost:44338/Buses/Index'
            }
        });
    });
})