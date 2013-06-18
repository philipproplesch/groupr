using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Groupr.Mvc.Extensions
{
    public static class AreaRegistrationContextExtensions
    {
        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url)
        {
            return context.MapLowercaseRoute(
                name, url, null);
        }

        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url,
            object defaults)
        {
            return context.MapLowercaseRoute(
                name, url, defaults, null);
        }

        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url,
            object defaults,
            object constraints)
        {
            return context.MapLowercaseRoute(
                name, url, defaults, constraints, null);
        }

        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url,
            string[] namespaces)
        {
            return context.MapLowercaseRoute(
                name, url, null, namespaces);
        }

        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url,
            object defaults,
            string[] namespaces)
        {
            return context.MapLowercaseRoute(
                name, url, defaults, null, namespaces);
        }

        public static Route MapLowercaseRoute(
            this AreaRegistrationContext context,
            string name,
            string url,
            object defaults,
            object constraints,
            string[] namespaces)
        {
            if (namespaces == null && context.Namespaces != null)
            {
                namespaces = context.Namespaces.ToArray();
            }

            var route =
                context.Routes.MapLowercaseRoute(
                    name, url, defaults, constraints, namespaces);

            route.DataTokens["area"] =
                context.AreaName;

            route.DataTokens["UseNamespaceFallback"] =
                namespaces == null || namespaces.Length == 0;

            return route;
        }
    }
}
