$(document).ready(function () {
    $("#btnDelete").click(function () {
        var CityId = $("#hidId");
        $.ajax({
            type: "POST",
            url: "/Cities/DeleteCity",
            data: '{id: ' + CityId.val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                window.location = 'https://localhost:44338/Cities/Index'
            }
        });
    });
})