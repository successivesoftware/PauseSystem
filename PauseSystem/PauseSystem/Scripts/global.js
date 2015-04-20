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
    },
    parseJsonResult: function (context) {
        return context.responseText ? $.parseJSON(context.responseText) : context;
    }
}
String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this); }
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2)); }
String.prototype.replaceAll = function (token, newToken, ignoreCase) { var _token; var str = this + ""; var i = -1; if (typeof token === "string") { if (ignoreCase) { _token = token.toLowerCase(); while ((i = str.toLowerCase().indexOf(token, i >= 0 ? i + newToken.length : 0)) !== -1) { str = str.substring(0, i) + newToken + str.substring(i + token.length); } } else { return this.split(token).join(newToken); } } return str; };

var $element = $('#responseAlertBox');
// can be "alert-warning","alert-danger","alert-primary"
var responseMessage = {
    timer: 3000,
    lastTimoutId:0,
    show: function (text, alertClass) {
        clearTimeout(responseMessage.lastTimoutId);
        if (!alertClass) alertClass = 'alert-success'; 
        $element.find('div').text(text);  
        $element.addClass(alertClass);
        $element.slideDown();
        responseMessage.lastTimoutId = setTimeout(function () {
            responseMessage.hide();
        }, responseMessage.timer);
    },
    showError: function (text) {
        if (!text) text = 'Something went wrong!';
        responseMessage.show(text, 'alert-danger');
    },
    hide: function () { $element.slideUp(); }
}



$(document).ready(function () {if (window.ready)window.ready();})
