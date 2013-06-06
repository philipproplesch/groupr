using System;
using System.Collections.Generic;
using System.Linq;
using Groupr.Core.Data;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using ServiceStack.OrmLite;

namespace Groupr.Core.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        public List<Meeting> GetMeetings()
        {
            using (var connection = Database.Factory.Open())
            {
                return connection
                    .Select<Meeting>()
                    .OrderBy(x => x.StartDate)
                    .ToList();
            }
        }

        public Meeting GetUpcomingMeeting()
        {
            using (var connection = Database.Factory.Open())
            {
                return connection
                    .Select<Meeting>(q => q.StartDate > DateTime.Now)
                    .FirstOrDefault();
            }
        }

        public bool CreateMeeting(Meeting meeting)
        {
            using (var connection = Database.Factory.Open())
            {
                connection.Insert(meeting);
                return connection.GetLastInsertId() > 0;
            }
        }

        public Meeting GetMeetingById(int id)
        {
            using (var connection = Database.Factory.Open())
            {
                return connection.QueryById<Meeting>(id);
            }
        }
    }
}