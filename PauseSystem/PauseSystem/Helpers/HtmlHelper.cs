using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace PauseSystem
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionHtmlLink(this System.Web.Mvc.AjaxHelper ajax,string htmlText,string actionName,string controllerName,object routeValues,
            AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return MvcHtmlString.Create(ajax.ActionLink("[*AnchorText]", actionName, controllerName, routeValues, ajaxOptions, htmlAttributes)
                            .ToString().Replace("[*AnchorText]", htmlText)
                            );

        }
    }
}