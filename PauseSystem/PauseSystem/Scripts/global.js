// These variables are assigned at _Layout page. assigning a value here will overide the existing value. 
var appBaseURL, appDateFormat, appDateTimeFormat;


var global = {
    initdatepicker: function (selector) {
        $(selector).datepicker({ format: appDateFormat, startDate: '0d', orientation: "top auto", autoclose: true });
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
    },
    mapUrl: function (args) {
        return appBaseURL + (arguments && arguments.length > 0 ? Array.prototype.slice.call(arguments).join('/') : '');
    }
}

var ajaxLoader = {
    show: function () {
        document.getElementById("bgLoader").style.display = "block";
    },
    hide: function () {
        document.getElementById("bgLoader").style.display = "none";
    }
};

String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this); }
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2)); }
String.prototype.replaceAll = function (token, newToken, ignoreCase) { var _token; var str = this + ""; var i = -1; if (typeof token === "string") { if (ignoreCase) { _token = token.toLowerCase(); while ((i = str.toLowerCase().indexOf(token, i >= 0 ? i + newToken.length : 0)) !== -1) { str = str.substring(0, i) + newToken + str.substring(i + token.length); } } else { return this.split(token).join(newToken); } } return str; };

// can be "alert-warning","alert-danger","alert-primary"
var responseMessage = {
    htmlwrapper: '<div id="responseAlertBox" class="alert alert-dismissable" style="position:fixed; display: none; z-index:9999; width:100%;">'
    + ' <button type="button" class="close" onclick="$(\'.alert\').slideUp()">&times;</button><div></div></div>',
    timer: 8000,
    lastTimoutId: 0,
    init: function () { $("body").prepend(this.htmlwrapper); },
    show: function (text, alertClass, autohide) {
        var $elm = $('#responseAlertBox');
        clearTimeout(responseMessage.lastTimoutId);
        if (!alertClass) alertClass = 'alert-success';
        if (alertClass == 'alert-success') { $elm.find('div').html('<strong>Success! </strong>' + text);}
        else { $elm.find('div').html('<strong>Error! </strong>' + text);}
        $elm.removeClass('alert-success').removeClass('alert-danger').addClass(alertClass);
        $elm.slideDown();
        if (autohide == undefined || autohide) { responseMessage.lastTimoutId = setTimeout(function () { responseMessage.hide(); }, responseMessage.timer);}
    },
    showError: function (text) { if (!text) text = 'Something went wrong!'; responseMessage.show(text, 'alert-danger'); },
    hide: function () { $('#responseAlertBox').slideUp();}
};
responseMessage.init();


$(document).ready(function () {if (window.ready)window.ready();})
