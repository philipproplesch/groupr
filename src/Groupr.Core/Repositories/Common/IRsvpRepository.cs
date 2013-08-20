using Groupr.Core.Models;

namespace Groupr.Core.Repositories.Common
{
    public interface IRsvpRepository
    {
        bool UpdateRsvp(Rsvp rsvp);
    }
}