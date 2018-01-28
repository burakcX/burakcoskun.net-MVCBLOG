using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBLOG.WEBUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
            name: "PostByCategoryUrl",
            url: "{controller}/PostByCategoryUrl/{SeoLinkUrl}",
            defaults: new { controller = "Home", action = "PostByCategoryUrl" }
            );

            routes.MapRoute(
                name: "ReadSeo",
                url: "{controller}/PostDetail/{seolink}",
                defaults: new { controller = "Home", action = "PostDetail" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
