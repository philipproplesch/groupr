using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;

namespace Groupr.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeetingRepository _eventRepository;
        private readonly ILocationRepository _locationRepository;

        public HomeController(
            IMeetingRepository eventRepository,
            ILocationRepository locationRepository)
        {
            _eventRepository = eventRepository;
            _locationRepository = locationRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        //void RegisterUser(string email, string last, string first)
        //{
        //    var token =
        //        WebSecurity.CreateUserAndAccount(
        //            email,
        //            "netug",
        //            propertyValues: new
        //            {
        //                MailAddress = email,
        //                FirstName = first,
        //                LastName = last,
        //            },
        //            requireConfirmationToken: false);

        //    Roles.AddUserToRole(
        //        email,
        //        WebRoles.Member);
        //}

        public ActionResult Imprint()
        {
            return View();
        }

        public ActionResult UpcomingEvent()
        {
            var meeting = _eventRepository.GetUpcomingMeeting();
            if (meeting == null)
            {
                return new EmptyResult();
            }

            var location =
                _locationRepository.GetLocationById(
                    meeting.LocationId);

            if (location == null)
            {
                return new EmptyResult();
            }

            var model =
                new UpcomingEventViewModel
                    {
                        Event = Mapper.Map<Meeting, MeetingViewModel>(meeting),
                        Location = Mapper.Map<Location, LocationViewModel>(location)
                    };

            return PartialView("_UpcomingEvent", model);
        }
    }
}