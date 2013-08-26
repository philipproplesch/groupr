using System.Web.Routing;

namespace Groupr.Mvc.Routing
{
    public class LowercaseRoute : Route
    {
        public LowercaseRoute(
            string url,
            IRouteHandler routeHandler)
            : base(url, routeHandler)
        { }

        public LowercaseRoute(
            string url,
            RouteValueDictionary defaults,
            IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        { }

        public LowercaseRoute(
            string url,
            RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        { }

        public LowercaseRoute(
            string url, RouteValueDictionary defaults,
            RouteValueDictionary constraints,
            RouteValueDictionary dataTokens,
            IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        { }

        public override VirtualPathData GetVirtualPath(
            RequestContext requestContext,
            RouteValueDictionary values)
        {
            var path = base.GetVirtualPath(requestContext, values);

            if (path != null)
            {
                if (path.VirtualPath.Contains("?"))
                {
                    var segments = path.VirtualPath.Split('?');

                    path.VirtualPath =
                        string.Concat(
                            segments[0].ToLowerInvariant(), "?", segments[1]);
                }
                else
                {
                    path.VirtualPath = path.VirtualPath.ToLowerInvariant();
                }
            }

            return path;
        }
    }
}