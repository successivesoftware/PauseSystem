var global = {
    initdatepicker: function (selector) {
        $(selector).datepicker({ format: 'mm/dd/yyyy', startDate: '0d', orientation: "top auto", autoclose: true });

        var dateFormat = $(selector).datepicker("option", "dateFormat");
        $(selector).datepicker("option", "dateFormat", "yy-mm-dd");
    },
    isNullOrEmpty: function (value) {
        return value == undefined || value == '';
    }

}
String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this); }
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2)); }


$(document).ready(function () {
    if (window.ready)
        window.ready();
})


function AjaxDeleteDayOfWeek(senderId) {
    $('#productTableId tr[data-group-id=' + senderId + ']').each(function () {
        $(this).remove();
    });
}

function AjaxDeleteProduct(senderId) {
    $('#productTableId tr[id=' + senderId + ']').each(function () {
        $(this).remove();
    });
}