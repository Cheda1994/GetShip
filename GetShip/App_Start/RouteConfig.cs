using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GetShip
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{firstArrg}",
                defaults: new { controller = "Home", action = "Index", firstArrg = UrlParameter.Optional }
                );
                            
            routes.MapRoute(
                name: "Second",
                url: "{controller}/{action}/{firstArrg}/{secondArrg}",
                defaults: new { controller = "Home", action = "Index", firstArrg = UrlParameter.Optional , secondArrg = UrlParameter.Optional}
            );



        }
    }
}
