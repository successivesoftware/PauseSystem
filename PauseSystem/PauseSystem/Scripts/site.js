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

    addProduct: function (produktNr, containerId) {
        if (isNaN(produktNr))
            return responseMessage.showError('Something wrong.');
        ajaxLoader.show();
        $.post('Home/AjaxAddProduct', { produktNr: produktNr }, function (html) {
            ajaxLoader.hide();
            $("#" + containerId).before(html);
            $("#" + containerId).find('input').val('');
        })
    },

    initProduktSearchAutoCompleter: function () {
        jsAutoCompleter.init('.search-produkt', { url: global.mapUrl('Home/AjaxGetProdukt'), displayField: 'HtmlString', valueField: "ProduktNr", minLength: 2 }, function (item, that) {
            that.value = "";
            if (confirm("Are you sure you want to add this produkt?")) {
                jsLiverenger.addProduct(item.value, that.getAttribute("data-container"));
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


var jsAutoCompleter = new function () {
    var instance = this;
    var selectedItem = {};
    var _defaultOptions = {
        url: '',
        minLength: 1,
        timeout: 500,
        selectedField: 'Name',
        displayField: 'Name',
        valueField: 'Id',
        method: 'GET',
        loadingClass: 'loader-small',
        renderHtml: null,
        readonlySelection:true,
    };
    this.advanceSelection = function (elm) {
      //  $(elm).after('<div class="typeahead-selected-text">' + elm.value + '</div>');
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
                    if (_options.selectedField != _options.displayField)
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
}

//<div><img src='{0}' style='max-height:50px;' /> <strong> {1} </strong> <label class='label label-warning' style='margin:left:10px;'> {2} <label> </div>