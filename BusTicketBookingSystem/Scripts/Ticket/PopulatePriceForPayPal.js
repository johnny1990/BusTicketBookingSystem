$("#Price").click(function () {
    $.ajax({
        type: "Get",
        url: '/Tickets/GetPriceForPayPal',
        data: { price: $("#Price").val() },
        dataType: "json",
        success: function (data) {
            $("#PriceP").val(data[0]);//find textbox
        }
    });
})