var global = {
    initdatepicker: function (selector) {
        $(selector).datepicker({ format: 'mm/dd/yyyy', startDate: '0d', orientation: "top auto", autoclose: true });
    },
    isNullOrEmpty:function(value){
        return value == undefined || value == '';
    }
}
String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this);}
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2));}


$(document).ready(function () {
    if (window.ready)
        window.ready();
})
