using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Data;
using Groupr.Core.Models;
using Groupr.Mvc.ViewModels;
using ServiceStack.OrmLite;

namespace Groupr.Mvc.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var message = Mapper.Map<MessageViewModel, Message>(model);
            using (var connection = Database.Factory.Open())
            {
                connection.Insert(message);
            }

            // TODO: Write message to ALL members in "Leader" role.

            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Leaders()
        {
            //var model = Mapper.Map<List<Member>, List<MemberViewModel>>(leaders);

            return PartialView("_ContactCards", new List<MemberViewModel>());
        }
    }
}
