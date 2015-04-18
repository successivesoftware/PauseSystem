var global = {
    initdatepicker: function (selector) {
        $(selector).datepicker({ format: 'mm/dd/yyyy', startDate: '0d', orientation: "top auto", autoclose: true });
        var dateFormat = $(selector).datepicker("option", "dateFormat");
        $(selector).datepicker("option", "dateFormat", "yy-mm-dd");
    },
    isNullOrEmpty: function (value) {
        return value == undefined || value == '';
    },
    showLoader: function (elm) {
        document.getElementById("bgLoader").style.display = "block";
    },
    hideLoader: function (elm) {
        document.getElementById("bgLoader").style.display = "none";
    }
}
String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this); }
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2)); }
$(document).ready(function () {if (window.ready)window.ready();})
