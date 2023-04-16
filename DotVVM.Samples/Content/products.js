$(function () {
    _.templateSettings = {
        interpolate: /\{\{(.+?)\}\}/g
    };

    const productTableTemplate = _.template($('#product-template').html());
    const dialogTemplate = _.template($('#product-dialog-template').html());

    const $productDialog = $('#product-dialog');
    $productDialog.dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }
    });

    // Sample product data
    $.get("/ProductsService.aspx", {},
        function (products) {
            _.each(products, function (product) {
                $('#products-table tbody').append(productTableTemplate({ product: product }));
            });
        }.bind(this));

    // Show the product dialog on row click
    $('#products-table tbody').on('click', 'tr', function (sender, event) {
        const id = new Number($(sender.currentTarget).find("input[type=hidden]").attr("value"));

        $.get("/ProductsService.aspx", {action: "detail", id: id},
            function (product) {
                $productDialog.html(dialogTemplate({ product: product }));
                $productDialog.dialog("open");
            }.bind(this));
    });
});