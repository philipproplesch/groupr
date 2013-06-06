using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;

namespace Groupr.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageRepository _repository;

        public ContactController(IMessageRepository repository)
        {
            _repository = repository;
        }

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
            if (_repository.SaveMessage(message))
            {
                // TODO: Write email to ALL members in "Leader" role.
                return RedirectToAction("ThankYou");    
            }

            return View();
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
