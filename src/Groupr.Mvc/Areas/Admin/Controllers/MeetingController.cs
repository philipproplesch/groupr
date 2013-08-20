using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Extensions;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;
using Postal;

namespace Groupr.Mvc.Areas.Admin.Controllers
{
    [Authorize(Roles = "Leader")]
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMemberRepository _memberRepository;

        public MeetingController(
            IMeetingRepository meetingRepository,
            ILocationRepository locationRepository,
            IMemberRepository memberRepository)
        {
            _meetingRepository = meetingRepository;
            _locationRepository = locationRepository;
            _memberRepository = memberRepository;
        }
        
        public ActionResult SendInvitations(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting == null)
            {
                return RedirectToAction("Index");
            }

            var location = _locationRepository.GetLocationById(meeting.LocationId);

            var ics = meeting.ToIcs();
            using (var ms = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(ics);
                ms.Write(bytes, 0, bytes.Length);

                var attachment = new Attachment(ms, "Appointment.ics");

                var members = _memberRepository.GetUsers();
                foreach (var member in members)
                {
                    dynamic email = new Email("Invitation");
                    email.To = member.MailAddress;
                    email.FirstName = member.FirstName;

                    email.MeetingId = meeting.Id;
                    
                    email.Name = meeting.Name;
                    email.Abstract = meeting.Abstract;
                    email.StartDate = meeting.StartDate;
                    email.SpeakerName = meeting.SpeakerName;
                    email.SpeakerWebSite = meeting.SpeakerWebSite;

                    email.LocationName = location.Name;
                    email.LocationStreet = location.Street;
                    email.LocationZipCode = location.ZipCode;
                    email.LocationCity = location.City;
                    email.LocationWebSite = location.WebSite;

                    email.Attach(attachment);
                    email.Send();
                }
            }

            return View();
        }

        public ActionResult Index()
        {
            var meetings = _meetingRepository.GetMeetings();
            var model = Mapper.Map<List<Meeting>, List<MeetingViewModel>>(meetings);

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new EditableMeetingViewModel();

            model.Locations =
                _locationRepository
                    .GetLocations()
                    .Select(location => new SelectListItem
                        {
                            Value = location.Id.ToString(),
                            Text = location.Name
                        })
                    .ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EditableMeetingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations =
                    _locationRepository
                        .GetLocations()
                        .Select(location => new SelectListItem
                            {
                                Value = location.Id.ToString(),
                                Text = location.Name
                            })
                        .ToList();

                return View(model);
            }

            var meeting = Mapper.Map<MeetingViewModel, Meeting>(model.Event);
            if (meeting != null && _meetingRepository.CreateMeeting(meeting))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}