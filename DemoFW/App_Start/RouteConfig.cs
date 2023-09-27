using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoFW {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "demo",
                url: "informe/{idioma}/{año}",
                defaults: new {
                    controller = "Demos", action = "Listados",
                    idioma = "es-es", año = DateTime.Now.Year.ToString()
                },
                constraints: new {
                    idioma = "[a-z]{2}-[a-z]{2}", año = @"\d{4}"
                    //httpMethod = "GET"
                }
                );

            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{id}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { id = @"\d+"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
