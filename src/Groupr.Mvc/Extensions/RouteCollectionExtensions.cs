using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Groupr.Mvc.Routing;

namespace Groupr.Mvc.Extensions
{
    public static class RouteCollectionExtensions
    {
        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url)
        {
            return MapLowercaseRoute(
                routes, name, url, null, null);
        }

        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url,
            object defaults)
        {
            return MapLowercaseRoute(
                routes, name, url, defaults, null);
        }

        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url,
            object defaults,
            object constraints)
        {
            return MapLowercaseRoute(
                routes, name, url, defaults, constraints, null);
        }

        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url,
            string[] namespaces)
        {
            return MapLowercaseRoute(
                routes, name, url, null, null, namespaces);
        }

        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url,
            object defaults,
            string[] namespaces)
        {
            return MapLowercaseRoute(
                routes, name, url, defaults, null, namespaces);
        }

        public static Route MapLowercaseRoute(
            this RouteCollection routes,
            string name,
            string url,
            object defaults,
            object constraints,
            string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route =
                new LowercaseRoute(url, new MvcRouteHandler())
                {
                    Defaults = CreateRouteValueDictionary(defaults),
                    Constraints = CreateRouteValueDictionary(constraints),
                    DataTokens = new RouteValueDictionary()
                };

            if (namespaces != null && namespaces.Length > 0)
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }

        private static RouteValueDictionary CreateRouteValueDictionary(
            object values)
        {
            var dictionary = values as IDictionary<string, object>;

            return
                dictionary != null
                    ? new RouteValueDictionary(dictionary)
                    : new RouteValueDictionary(values);
        }
    }
}