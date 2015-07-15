
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

function delayExecution(code) {
    setTimeout(code, 10);
};

var jsAbonnementer = {

    initAddressSearchAutoCompleter: function () {
        jsAutoCompleter.init('#Adresse', { url: global.mapUrl('Home/AjaxGetAdresse'), displayField: 'DisplayAdresse', selectedField: 'Adresse', valueField: "Id", minLength: 1 }
            , function (item, that) {
                document.getElementById("AddressId").value = parseInt(item.Id);
            });
    },

    initProduktSearchAutoCompleter: function () {
        jsAutoCompleter.init('#SearchProdukt', { url: global.mapUrl('Home/AjaxGetProduktForPreAbonnement'), displayField: 'DisplayProdukt', selectedField: 'Name', valueField: "ProduktNr", minLength: 1 }
            , function (item, that) {
                document.getElementById("ProduktNr").value = parseInt(item.ProduktNr);
            });
    },

}
var jsLiverenger = {
    // delete
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

    changeAntal: function (producktNo, targetId, mode, tempAbonnement, id, addressId, date) {
        var value = document.getElementById(targetId).innerHTML;
        ajaxLoader.show();
        if (tempAbonnement == 1)
        {
            addressId = null;
            date = null;
            producktNo = null;
        }
        else
        {
            id = null;
        }
        $.post('Home/AjaxChangeAntalValue', { produktNumber: producktNo, antalValue: value, mode: mode, preAbonnementId: id, addressId: addressId, date: date }, function (result) {
            ajaxLoader.hide();
            document.getElementById(targetId).innerHTML = result;
        });
    },

    addProduct: function (produktNr, containerId, adressId, date) {
       
        if (isNaN(produktNr))
            return responseMessage.showError('Something wrong.');
        ajaxLoader.show();
        $.post('Home/AjaxAddProduct', { produktNr: produktNr, adressId: adressId, date: date }, function (html) {
            ajaxLoader.hide();
            $("#" + containerId).before(html);
            $("#" + containerId).find('input').val('');
        })
    },

    initProduktSearchAutoCompleter: function () {
        jsAutoCompleter.init('.search-produkt', { url: global.mapUrl('Home/AjaxGetProdukt'), displayField: 'HtmlString', selectedField: 'HtmlString', valueField: "ProduktNr", minLength: 2 }
            , function (item, that) {
                delayExecution(function () {
                    that.value = "";
                });
                if (confirm("Are you sure you want to add this produkt?")) {
                    console.log(that.getAttribute("adressId"));
                    jsLiverenger.addProduct(item.ProduktNr, that.getAttribute("data-container"), that.getAttribute("adressId"), that.getAttribute("date"));
                }
            });
    },
    initCustomerSearchAutoCompleter: function () {
        jsAutoCompleter.init('#KundeName', { url: global.mapUrl('Home/AjaxGetKunder'), displayField: 'DisplayName', selectedField: 'Name', valueField: "Id", minLength: 1 }
            , function (item, that) {
                document.getElementById("KundeId").value = parseInt(item.Id);
            });
    }
}


var jsAutoCompleter = {
    init: function (selector, options, selectCallback) {
        new AutoCompleter().init(selector, options, selectCallback);
    }
}

function AutoCompleter() {
    var instance = this;
    var selectedItem = {};
    var _defaultOptions = {
        url: '',
        minLength: 1,
        timeout: 500,
        selectedField: undefined,
        displayField: 'Name',
        valueField: 'Id',
        method: 'GET',
        loadingClass: 'loader-small',
        renderHtml: null,
        readonlySelection: true,
    };
    this.advanceSelection = function (elm) {
        //$(elm).after('<div class="typeahead-selected-text">' + elm.value + '</div>');
    },
    this.init = function (selector, options, selectCallback) {
        //reference https://github.com/biggora/bootstrap-ajax-typeahead
        var _options = $.extend(_defaultOptions, options);
        if (!_options.selectedField || _options.selectedField == '')
            _options.selectedField = _options.displayField;

        $(selector).each(function () {
            var _that = this;
            var sourceElms = {};
            $(_that).typeahead({
                onSelect: function (item) {
                    selectedItem = sourceElms[item.value];
                    setTimeout(function () {
                        _that.value = selectedItem[_options.selectedField];
                        $(_that).addClass("typeahead-selected-input");
                        if (_options.readonlySelection) instance.advanceSelection(_that);
                    }, 10);
                    if (selectCallback) selectCallback(selectedItem, _that);
                },
                ajax: {
                    url: _options.url,
                    timeout: _options.timeout,
                    displayField: _options.displayField,
                    valueField: _options.valueField,
                    triggerLength: _options.minLength,
                    method: _options.method
                    , loadingClass: _options.loadingClass
                    , preProcess: function (response) {
                        if (response.isSuccess === false) {
                            // Hide the list, there was some error
                            return false;
                        }
                        var data = response.data;
                        for (i in response.data) {
                            sourceElms[response.data[i][_options.valueField]] = response.data[i];
                        };
                        return response.data;
                    }
                }
            });
        });
    }
    return instance;
}

//<div><img src='{0}' style='max-height:50px;' /> <strong> {1} </strong> <label class='label label-warning' style='margin:left:10px;'> {2} <label> </div>