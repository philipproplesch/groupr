using System;
using System.Web.Mvc;
using Groupr.Core.Data;
using Groupr.Core.Membership;
using Groupr.Core.Models;
using Groupr.Mvc.Filters;
using ServiceStack.OrmLite;

namespace Groupr.Mvc.Controllers
{
    //[Authorize]
    [InitializeSimpleMembership]
    public class DataController : Controller
    {
#if DEBUG
        private Type[] types =
            new[] {
                typeof (Location),
                typeof (Meeting),
                typeof (Rsvp),
                typeof(Sponsor),

                typeof (UserMembership),
                typeof (OAuthUserMembership),
                typeof (UserRole),
                typeof (UsersInRoles),
                typeof (UserProfile)
            };

        public ActionResult DropSchema()
        {
            using (var connection = Database.Factory.OpenDbConnection())
            {
                connection.DropTables(types);
            }

            return Content("Finished!", "text/plain");
        }

        public ActionResult CreateSchema()
        {
            using (var connection = Database.Factory.OpenDbConnection())
            {
                connection.CreateTables(false, types);
            }

            return Content("Finished!", "text/plain");
        }
#endif
    }
}
