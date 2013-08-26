using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Groupr.Core.Extensions;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using Groupr.Mvc.ViewModels;
using Postal;
using ServiceStack.Logging;

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

        public ActionResult SendInvitationToLeaders(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting == null)
            {
                return RedirectToAction("Index");
            }

            var ics = meeting.ToIcs();

            var location = _locationRepository.GetLocationById(meeting.LocationId);

            var members = _memberRepository.GetLeaders();
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

                // TODO: Add iCal as attachment.

                var log = LogManager.GetLogger(GetType());
                try
                {
                    log.InfoFormat("SendInvitationToLeaders: {0}", member.MailAddress);
                    email.Send();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult SendInvitationToMembers(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting == null)
            {
                return RedirectToAction("Index");
            }
            
            var location = _locationRepository.GetLocationById(meeting.LocationId);

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

                // TODO: Add iCal as attachment.
                
                var log = LogManager.GetLogger(GetType());
                try
                {
                    log.InfoFormat("SendInvitationToMembers: {0}", member.MailAddress);
                    email.Send();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }

            return RedirectToAction("Index");
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