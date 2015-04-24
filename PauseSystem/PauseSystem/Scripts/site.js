
var jsLiverenger = {
    deleteDelivery: function (id, jsonResult) {
        var result = global.parseJsonResult(jsonResult);
        if (result.isSuccess) {
            responseMessage.show('Record deleted successfully.');
            $("#" + id).remove();
        }
        else {
            responseMessage.showError();
        }
    },
    deleteDeliveryWeek: function (id, jsonResult) {
        console.log(id);
        console.log(jsonResult);

        var result = global.parseJsonResult(jsonResult);
        if (result.isSuccess) {
            responseMessage.show('Record deleted successfully.');
            $("#" + id).remove();
        }
        else {
            responseMessage.showError();
        }
    },

    updateAntal: function (id, operation) {
        alert(id);
        var cont = parseInt($("#" + id).text(), 10);
        if ((operation == 0) && (cont > 0)) {
            $("#" + id).text(cont - 1);
        }
        else if (operation == 1) {
            $("#" + id).text(cont + 1);
        }
    },

    addTypeaheadRow: function (id) {
        $("#" + id).show();
    },

    initiateAutocompleter: function () {

        $("input[type=text][action-type=typeahead]").each(function () {

            var $productName = $("#product_" + $(this).attr("action-data")); 
            var $productId = $("#hiddenProductId_product_" + $(this).attr("action-data"));
            var $productVarenr = $("#hiddenProductVarenr_product_" + $(this).attr("action-data"));
            var $productBeskrivelse = $("#hiddenProductBeskrivelse_product_" + $(this).attr("action-data"));
            var $productPris = $("#hiddenProductPris_product_" + $(this).attr("action-data"));
            var $productSPris = $("#hiddenProductSPris_product_" + $(this).attr("action-data"));

            var temp = {};
            $productName.typeahead({
                
                source: function (query, process) {

                    var $items = [""];

                    $.post("http://localhost:1344/home/getProductName", { "filterKey": query, "limit": 5 }, function (data) {

                        if (data.length != 0) {

                            $productId.val(data[0].value);
                            $productVarenr.val(data[0].varenr);
                            $productBeskrivelse.val(data[0].text);
                            $productPris.val(data[0].price);
                            $productSPris.val(data[0].sprice);

                            $.map(data, function (item) {

                                var group = {

                                    id: item.value,

                                    name: item.text,

                                    img: item.img,

                                    price: item.price,

                                    varenr: item.varenr,

                                    sprice: item.sprice


                                };

                                $items.push(group);
                                temp[item.text] = item;
                            });

                            process($items);

                        } else {

                            $productName.typeahead('hide');

                            $productId.val('');
                        }
                    });
                },
                
                highlighter: function (item) {
                    var productObject = temp[item];
                    return '<div class="test">' + '<img src="' + productObject.img + '" /> | ' + '<strong>' + productObject.text + '</strong> | ' + productObject.price + ' </div>';
                },

                items: 5,

                minLength: 1,

                highlight: true,

                updater: function (selectedItem) {
                    $productId.val(selectedItem.id);
                    $productVarenr.val(selectedItem.varenr);
                    $productBeskrivelse.val(selectedItem.name);
                    $productPris.val(selectedItem.price);
                    $productSPris.val(selectedItem.sprice);
                    return selectedItem.name;
                },

                clear: function () {

                    if (common.isNullOrEmpty($ContactName.val())) {

                        $productId.val('');
                    }
                }
            })
        });
    },

    addNewRow: function (id, tableId) {
        var productId = $("#hiddenProductId_" + id).val();
        var antal = $("#hiddenProductAntal_" + id).val();
        var varenr = $('#hiddenProductVarenr_' + id).val();
        var beskrivelse = $("#hiddenProductBeskrivelse_" + id).val();
        var pris = $("#hiddenProductPris_" + id).val();
        var sPris = $("#hiddenProductSPris_" + id).val();
        var row = '<tr id=' + productId + '>'
                    + '<td><div id="Antal' + productId + '" style="float:left">' + 5 + '</div>'
                                     + '<a href=/Home/AjaxUpdateAntal?produktNumber=' + varenr + '&amp;operation=1 data-ajax-method="Post" data-ajax-loading="#bgLoader" data-ajax-complete="jsLiverenger.updateAntal(Antal' + varenr + ',1)" data-ajax="true">+</a>'
                                     + '<a href="/Home/AjaxUpdateAntal?produktNumber=' + varenr + '&amp;operation=0" data-ajax-method="Post" data-ajax-loading="#bgLoader" data-ajax-complete="jsLiverenger.updateAntal(Antal' + varenr + ',0)" data-ajax="true">-</a>'
                    + '</td>'
                    + '<td>' + varenr + '</td>'
                    + '<td>' + beskrivelse + '</td>'
                    + '<td>' + pris + '</td>'
                    + '<td>' + sPris + '</td>'
                    + '<td> <a href="/Home/AjaxDeleteDelivery/' + productId + '" data-ajax-method="Post" data-ajax-loading="#bgLoader" data-ajax-confirm="Do you want to delete this delivery?" data-ajax-complete="jsLiverenger.deleteDelivery(' + productId + ',xhr)" data-ajax="true">Delete</a> </td>'
                    + '</tr>'

        $("#" + tableId).append(row);


    }
}

$(document).ready(function () {
    jsLiverenger.initiateAutocompleter();
})