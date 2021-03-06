﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PauseSystem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults : new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "LogOff",
                url: "LogOff/{optional}",
                defaults: new { controller = "Account", action = "LogOff", optional = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Subscriptions",
                url: "Subscriptions",
                defaults: new { controller = "Home", action = "Subscriptions" }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}
