$("#Trip_Id").change(function () {
    $.ajax({
        type: "Get",
        url: '/Tickets/GetTicketPrice',
        data: { tourId: $("#Trip_Id").val() },
        dataType: "json",
        success: function (data) {
            $("#Price").val(data[0]);
        }
    });
})