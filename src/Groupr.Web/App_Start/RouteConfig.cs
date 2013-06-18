using System.Web.Mvc;
using System.Web.Routing;
using Groupr.Mvc.Extensions;

namespace Groupr.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapLowercaseRoute(
                name: "Imprint",
                url: "Imprint",
                defaults: new { controller = "Home", action = "Imprint" }
            );

            routes.MapLowercaseRoute(
                name: "NewsletterOptInOut",
                url: "{controller}/{action}/{token}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapLowercaseRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}