using System.Web.Mvc;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;

namespace Groupr.Mvc.Controllers
{
    //[Authorize]
    public class RsvpController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IRsvpRepository _rsvpRepository;

        public RsvpController(
            IMemberRepository memberRepository,
            IRsvpRepository rsvpRepository)
        {
            _memberRepository = memberRepository;
            _rsvpRepository = rsvpRepository;
        }

        [Authorize]
        public ActionResult Attend(int id)
        {
            var profile =
                _memberRepository.GetMemberByUserName(
                    User.Identity.Name);

            _rsvpRepository.UpdateRsvp(new Rsvp
            {
                MemberId = profile.UserId,
                EventId = id,
                Status = RsvpStatus.Accepted
            });

            return View("Accept");
        }

        public ActionResult Accept(string hash, int id)
        {
            var profile =
                _memberRepository.GetMemberByHash(hash);

            _rsvpRepository.UpdateRsvp(new Rsvp
                {
                    MemberId = profile.UserId,
                    EventId = id,
                    Status = RsvpStatus.Accepted
                });

            return View();
        }

        public ActionResult Decline(string hash, int id)
        {
            var profile =
                _memberRepository.GetMemberByHash(hash);

            _rsvpRepository.UpdateRsvp(new Rsvp
                {
                    MemberId = profile.UserId,
                    EventId = id,
                    Status = RsvpStatus.Declined
                });

            return View();
        }
    }
}