// These variables are assigned at _Layout page. assigning a value here will overide the existing value. 
var appBaseURL, appDateFormat, appDateTimeFormat, serverResponseMessage;

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

var ajaxLoader = new function () {
    var instance = this, elm, img = 'Content/Images/loading.gif'
        , htmlwrapper = '<div id="bgLoader" style="display:none"><div class="fade"></div><div class="loader"><img src="' + img + '" alt="Processing..." /></div></div>';
    var init = function () {
        $("body").prepend(htmlwrapper); elm = document.getElementById("bgLoader");
    };
    this.show = function () {
        elm.style.display = "block";
    };
    this.hide = function () {
        elm.style.display = "none";
    };
   init();
};

var responseMessage = new function () {
    //can be "alert-warning","alert-danger","alert-primary"
    var instance = this, $elm, timer = 8000, lastTimoutId = 0
        , aclasses = ['alert-danger', 'alert-success', 'alert-warning']
        ,htmlwrapper = '<div id="responseAlertBox" class="alert alert-dismissable" style="position:fixed; display: none; z-index:9999; width:100%;">'
                    + ' <button type="button" class="close" onclick="$(\'.alert\').slideUp()">&times;</button><div></div></div>';
    var init = function () {
        $("body").prepend(htmlwrapper); $elm = $('#responseAlertBox');
    };
    this.show = function (text, cIndex, autohide) {
        // cIndex = 1 => 'Success' , 0 => Error ,2 => Warning
        clearTimeout(lastTimoutId);
        cIndex = isNaN(cIndex) ? 1 : cIndex;
        if (cIndex == 1) {
            $elm.find('div').html('<strong>Success! </strong> ' + text);
        }
        else {
            $elm.find('div').html('<strong>Error! </strong> ' + text);
        }
        $elm.removeClass(aclasses[0]).removeClass(aclasses[1]).removeClass(aclasses[2]).addClass(aclasses[cIndex]);
        $elm.slideDown();
        if (autohide == undefined || autohide) {
            lastTimoutId = setTimeout(function () { instance.hide(); }, timer);
        }
    };
    this.showError = function (text) {
        if (!text) text = 'Something went wrong!'; responseMessage.show(text, 0);
    };
    this.hide = function () {
        $elm.slideUp();
    }
    init();
};

String.prototype.isDate = function () { return !global.isNullOrEmpty(this) && Date.parse(this); }
Date.prototype.isGreator = function (date2) { return !global.isNullOrEmpty(date2) && (this > Date.parse(date2)); }
String.prototype.replaceAll = function (token, newToken, ignoreCase) { var _token; var str = this + ""; var i = -1; if (typeof token === "string") { if (ignoreCase) { _token = token.toLowerCase(); while ((i = str.toLowerCase().indexOf(token, i >= 0 ? i + newToken.length : 0)) !== -1) { str = str.substring(0, i) + newToken + str.substring(i + token.length); } } else { return this.split(token).join(newToken); } } return str; };


$(document).ready(function () {
    if (window.ready) window.ready();
    if (serverResponseMessage && !global.isNullOrEmpty(serverResponseMessage)) {
        var smsg = serverResponseMessage.split('_');
        if(smsg[0] == 'Error') responseMessage.showError(smsg[1]);
        else responseMessage.show(smsg[1]);
    }
});
