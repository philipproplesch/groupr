using System.Web.Mvc;
using System.Web.Routing;

namespace Groupr.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Imprint",
				url: "Imprint",
				defaults: new { controller = "Home", action = "Imprint" }
			);

			routes.MapRoute(
				name: "NewsletterOptInOut",
				url: "{controller}/{action}/{token}",
				defaults: new { controller = "Home", action = "Index" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}