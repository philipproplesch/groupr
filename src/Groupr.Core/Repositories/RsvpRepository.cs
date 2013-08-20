using Groupr.Core.Data;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using ServiceStack.OrmLite;

namespace Groupr.Core.Repositories
{
    public class RsvpRepository : IRsvpRepository
    {
        public bool RsvpMist(Rsvp rsvp)
        {
            using (var connection = Database.Factory.Open())
            {
                var previousRsvp =
                    connection.First<Rsvp>(x => x.EventId == rsvp.EventId && x.MemberId == rsvp.MemberId);

                if (previousRsvp != null)
                {
                    previousRsvp.Status = rsvp.Status;

                    connection.Update(previousRsvp);
                    return true;
                }

                connection.Insert(rsvp);
                return connection.GetLastInsertId() > 0;
            }
        }
    }
}
