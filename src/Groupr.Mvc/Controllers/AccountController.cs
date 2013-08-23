using System.Web.Mvc;
using System.Web.Security;
using Groupr.Mvc.ViewModels;
using Postal;
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

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!WebSecurity.UserExists(model.MailAddress))
            {
                return View();
            }

            var token =
                WebSecurity.GeneratePasswordResetToken(model.MailAddress);

            dynamic email = new Email("ChangePassword");
            email.To = model.MailAddress;
            email.ResetLink = Url.Action("ChangePassword", "Account", new { token, area = "" }, Request.Url.Scheme);

            email.Send();

            return RedirectToAction("Login");
        }

        public ActionResult ChangePassword(string token)
        {
            return View(new ChangePasswordViewModel { Token = token });
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (WebSecurity.ResetPassword(model.Token, model.NewPassword))
            {
                return RedirectToAction("Login");
            }

            return RedirectToAction("ForgotPassword");
        }
    }
}