

//function AjaxDeleteDayOfWeek(senderId) {
//    return;
//    $('#productTableId tr[data-group-id=' + senderId + ']').each(function () {
//        $(this).remove();
//    });
//}

//function AjaxDeleteProduct(senderId) {
//    return;
//    $('#productTableId tr[id=' + senderId + ']').each(function () {
//        $(this).remove();
//    });
//}


var jsLiverenger = {
    deleteDelivery: function (id) {
        $("#" + id).remove();
    },
    deleteDeliveryWeek: function (id) {
        $("#" + id).remove();
    }
}

var responseMessage = {
    show: function (text, alertClass) {
        $('#responseMessage').text(text);   //Message div inside responseAlertBox div
        var element = $('#responseAlertBox');
        element.addClass(alertClass);
        element.slideDown();
    },
    hide: function () {
        $('#ResponseAlertBox').slideUp();
    }
}