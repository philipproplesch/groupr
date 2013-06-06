using System;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;
using Groupr.Core.Security;
using WebMatrix.WebData;

namespace Groupr.Mvc.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = (string)filterContext.RouteData.Values["controller"];
            if (controller.Equals("data", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        // ReSharper disable ClassNeverInstantiated.Local
        private class SimpleMembershipInitializer
        // ReSharper restore ClassNeverInstantiated.Local
        {
            public SimpleMembershipInitializer()
            {
                try
                {
                    WebSecurity.InitializeDatabaseConnection("Groupr", "UserProfile", "UserId", "UserName", false);

                    if (!Roles.RoleExists(WebRoles.Leader))
                    {
                        Roles.CreateRole(WebRoles.Leader);
                    }

                    if (!Roles.RoleExists(WebRoles.Member))
                    {
                        Roles.CreateRole(WebRoles.Member);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}