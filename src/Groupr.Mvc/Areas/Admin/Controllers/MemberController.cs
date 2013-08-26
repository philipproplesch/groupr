using System.Linq;
using System.Web.Mvc;
using Groupr.Core.Data;
using Groupr.Core.Membership;
using Postal;
using ServiceStack.OrmLite;
using WebMatrix.WebData;

namespace Groupr.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Leader")]
    public class MemberController : Controller
    {
        public ActionResult SendPasswortResetPrompt()
        {
            using (var connection = Database.Factory.Open())
            {
                var users =
                    connection
                        .Select<UserMembership>()
                        .Where(x => string.IsNullOrEmpty(x.Password));

                foreach (var user in users)
                {
                    var profile =
                        connection.GetById<UserProfile>(user.UserId);

                    var token =
                        WebSecurity.GeneratePasswordResetToken(profile.MailAddress);

                    dynamic email = new Email("ChangePassword");
                    email.To = profile.MailAddress;
                    email.ResetLink =
                        Url.Action(
                            "ChangePassword",
                            "Account",
                            new {token, area = ""},
                            Request.Url.Scheme);

                    email.Send();
                }
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
