

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
    show: function (text) {

    },
    hide: function () {

    }
}