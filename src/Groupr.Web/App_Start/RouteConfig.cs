using System.Web.Mvc;
using System.Web.Routing;
using Groupr.Mvc.Extensions;

// ReSharper disable CheckNamespace
namespace Groupr.Web
// ReSharper restore CheckNamespace
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

            //routes.MapLowercaseRoute(
            //    name: "NewsletterOptInOut",
            //    url: "{controller}/{action}/{token}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);

            routes.MapLowercaseRoute(
                name: "RsvpAccept",
                url: "rsvp/accept/{hash}/{id}",
                defaults: new { controller = "Rsvp", action = "Accept" },
                namespaces: new[] { "Groupr.Mvc.Controllers" }
            );

            routes.MapLowercaseRoute(
                name: "RsvpDecline",
                url: "rsvp/decline/{hash}/{id}",
                defaults: new { controller = "Rsvp", action = "Decline" },
                namespaces: new[] { "Groupr.Mvc.Controllers" }
            );

            routes.MapLowercaseRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Groupr.Mvc.Controllers" }
            );
        }
    }
}