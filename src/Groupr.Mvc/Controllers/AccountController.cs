using System.Web.Mvc;
using System.Web.Security;
using Groupr.Mvc.ViewModels;
using WebMatrix.WebData;

namespace Groupr.Mvc.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (WebSecurity.Login(model.MailAddress, model.Password, true))
            {
                var returnUrl = ValueProvider.GetValue("ReturnUrl");
                if (returnUrl != null)
                {
                    return Redirect(returnUrl.AttemptedValue);
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}