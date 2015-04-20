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
