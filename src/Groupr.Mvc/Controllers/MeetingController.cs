using System.Text;
using System.Web.Mvc;
using Groupr.Core.Extensions;
using Groupr.Core.Repositories.Common;

namespace Groupr.Mvc.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingRepository _meetingRepository;

        public MeetingController(
            IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public ActionResult Ical(int id)
        {
            var meeting = _meetingRepository.GetMeetingById(id);
            if (meeting == null)
            {
                return RedirectToAction("Index");
            }

            var name = string.Concat(meeting.Name, ".ics");

            var ics = meeting.ToIcs();
            var bytes = Encoding.UTF8.GetBytes(ics);
                
            return File(bytes, "text/calendar", name);
        } 
    }
}