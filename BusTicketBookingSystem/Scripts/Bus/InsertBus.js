$(document).ready(function () {
    $("#btnCreate").click(function () {
        var txtNrReg = $("#txtNrReg");
        var txtNrSeats = $("#txtNrSeats");
        var ddDriverId = $("#ddDriverId");

        $.ajax({
            type: "POST",
            url: "/Buses/InsertBus",
            data: '{NrReg: "' + txtNrReg.val() + '", NrSeats: "' + txtNrSeats.val() + '", DriverId: "' + ddDriverId.val() + '"  } ',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {

                window.location = 'https://localhost:44338/Buses/Index'

            }

        })
    });
})