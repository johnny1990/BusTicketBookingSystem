$(document).ready(function () {
    $("#btnUpdate").click(function () {

        var bus = {};
        bus.BusId = $("#hidId").val();
        bus.NrReg = $("#txtNrReg").val();
        bus.NrSeats = $("#txtNrSeats").val();
        bus.DriverId = $("#ddDriverId").val();

        $.ajax({
            type: "POST",
            url: "/Buses/UpdateBus",
            data: '{bus:' + JSON.stringify(bus) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                window.location = 'https://localhost:44338/Buses/Index'
            }
        });

    });
})