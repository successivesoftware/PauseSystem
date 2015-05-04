function executeFunctionByName(functionName) {
    context = window;
    var args = [].slice.call(arguments).splice(1);
    var namespaces = functionName.split(".");
    var func = namespaces.pop();
    for (var i = 0; i < namespaces.length; i++) {
        context = context[namespaces[i]];
    }
    return context[func].apply(this, args);
}


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
    changeAntal: function (producktNo, targetId, mode) {
        var value = document.getElementById(targetId).innerHTML;
        ajaxLoader.show();
        $.post('Home/AjaxChangeAntalValue', { produktNumber: producktNo, value: value, mode: mode }, function (result) {
            ajaxLoader.hide();
            document.getElementById(targetId).innerHTML = result;
        })
    },

    addProduct: function (item, containerId) {
        ajaxLoader.show();
        $.post('Home/AjaxAddProduct', { producktNr: item.ProducktNr }, function (html) {
            ajaxLoader.hide();
            $("#" + containerId).before(html);
            $("#" + containerId).find('input').val('');
        })
    },

    initiateAutocompleter: function () {
        $("input[type=text][action-type=typeahead]").each(function () {
            var $elm = $(this);
            var funcSelect = $elm.attr("action-onselect");
            var containerId = $elm.attr("data-container");
            $elm.typeahead({
                minLength:3,
                source: function (query, process) {
                    $.post("Home/AjaxSearchProdukt", { "q": query, "limit": 5 }, function (response) {
                        if (response.isSuccess) {
                            var data = response.data;
                            if (data.length != 0) {
                                process(data);
                            } else {
                                $elm.typeahead('hide');
                            }
                        }
                    });
                },
                highlighter: function (name) { return name; },
                items: 5,
                highlight: true,
                updater: function (item) {
                    try {
                        if (funcSelect) executeFunctionByName(funcSelect, item, containerId);
                    }
                    catch (e) { console.log(e); }
                    return item.ProduktName;
                },
                clear: function () {
                    $elm.val("");
                }
            })
        });
    },


    //addNewRow: function (id, tableId) {
    //    var id = $("#hiddenProductId_" + id).val();
    //    var antal = $("#hiddenProductAntal_" + id).value;
    //    var varenr = $("#hiddenProductVarenr_" + id).val();
    //    var beskrivelse = $("#hiddenProductBeskrivelse_" + id).attr("value");
    //    var pris = $("#hiddenProductPris_" + id).value;
    //    var sPris = $("#hiddenProductSPris_" + id).value;
    //    var row = '<tr>'
    //                + '<td>' + antal + '</td>'
    //                + '<td>' + varenr + '</td>'
    //                + '<td>' + beskrivelse + '</td>'
    //                + '<td>' + pris + '</td>'
    //                + '<td>' + sPris + '</td>'
    //                + '</tr>'

    //    $("#" + tableId).append(row);
    //}

}

//$(document).ready(function () {
//    jsLiverenger.initiateAutocompleter();
//})