using System;
using System.Web.Mvc;
using Groupr.Core.Membership;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;
using Postal;
using ServiceStack.Logging;
using WebMatrix.WebData;

namespace Groupr.Mvc.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public NewsletterController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public ActionResult SignUp(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_SignUpPanel", model);
            }

            if (WebSecurity.UserExists(model.MailAddress))
            {
                // TODO: Already registered. Don't care about this for the moment.
                return PartialView("_SignUpPanel");
            }

            var token =
                WebSecurity.CreateUserAndAccount(
                    model.MailAddress,
                    model.Password,
                    propertyValues: new
                    {
                        model.MailAddress,
                        model.FirstName,
                        model.LastName,
                    },
                    requireConfirmationToken: true);

            dynamic email = new Email("Subscribed");
            email.To = model.MailAddress;
            email.FirstName = model.FirstName;
            email.OptInLink = Url.Action("OptIn", "Newsletter", new { token }, Request.Url.Scheme);

            var log = LogManager.GetLogger(GetType());
            try
            {
                log.InfoFormat("SignUp: {0}", model.MailAddress);
                email.Send();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

            return PartialView("_SignUpSucceededPanel");
        }

        public ActionResult OptIn(string token)
        {
            var profile = _memberRepository.OptIn(token);
            if (profile != null)
            {
                SendEmail("OptInSucceeded", token, profile);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OptOut(string token)
        {
            var profile = _memberRepository.OptOut(token);
            if (profile != null)
            {
                SendEmail("OptOutSucceeded", token, profile);
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        private void SendEmail(string template, string token, UserProfile profile)
        {
            dynamic email = new Email(template);
            email.To = profile.MailAddress;
            email.FirstName = profile.FirstName;
            email.OptOutLink = Url.Action("OptOut", "Newsletter", new { token }, Request.Url.Scheme);

            var log = LogManager.GetLogger(GetType());
            try
            {
                log.InfoFormat("SendEmail: {0}", profile.MailAddress);
                email.Send();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        public JsonResult ValidateEmail(string mailaddress)
        {
            var user = _memberRepository.GetMemberByUserName(mailaddress);
            return Json(user == null, JsonRequestBehavior.AllowGet);
        }
    }
}
