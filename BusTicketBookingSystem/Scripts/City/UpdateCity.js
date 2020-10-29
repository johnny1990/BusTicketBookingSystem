$(document).ready(function () {
    $("#btnUpdate").click(function () {

        var city = {};
        city.CityId = $("#hidId").val();
        city.Name = $("#txtName").val();

        $.ajax({
            type: "POST",
            url: "/Cities/UpdateCity",
            data: '{city:' + JSON.stringify(city) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                window.location = 'https://localhost:44338/Cities/Index'
            }
        });

    });
})