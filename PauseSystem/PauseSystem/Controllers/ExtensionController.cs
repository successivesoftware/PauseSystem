using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PauseSystem.Controllers
{
    public static class ExtensionController
    {
        public static System.Web.Mvc.JsonResult ToJsonResult(this System.Web.Mvc.Controller controller, object data)
        {
            return ToJsonResult(controller, data: data, message: null, jsonResultType: JsonResultTypes.Success);
        }

        public static System.Web.Mvc.JsonResult ToJsonResult(this System.Web.Mvc.Controller controller, object data, string message,
                JsonResultTypes jsonResultType)
        {
            return new System.Web.Mvc.JsonResult()
            {
                Data = new JsonResultData
                {
                    data = data,
                    message = message,
                    type = jsonResultType
                },
                JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet
            };
        }


        public static void SetResponse(this Controller controller,string message,bool IsError = false)
        {
            controller.TempData["ServerResponseMessage"] = (IsError ? "Error" : "Success") + "_" + message;
        }


        public static System.Web.Mvc.JsonResult ToJsonError(this System.Web.Mvc.Controller controller, string message)
        {
            return ToJsonResult(controller, data: String.Empty, message: null, jsonResultType: JsonResultTypes.Error);
        }

        public static string GetFirstError(this ModelState modelState)
        {
            return modelState.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
        }




        [Serializable]
        public class JsonResultData
        {
            public object data { get; set; }
            public string message { get; set; }
            public bool isSuccess { get { return type == JsonResultTypes.Success; } }
            public JsonResultTypes type { get; set; }

        }
    }
    public enum JsonResultTypes
    {
        Success, Error
    }



}
