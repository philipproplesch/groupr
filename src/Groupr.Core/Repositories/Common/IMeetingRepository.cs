using System.Collections.Generic;
using Groupr.Core.Models;

namespace Groupr.Core.Repositories.Common
{
    public interface IMeetingRepository
    {
        List<Meeting> GetMeetings();
        Meeting GetUpcomingMeeting();
        bool CreateMeeting(Meeting meeting);
        Meeting GetMeetingById(int id);
    }
}