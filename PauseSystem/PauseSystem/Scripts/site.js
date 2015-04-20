
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
    }
}

