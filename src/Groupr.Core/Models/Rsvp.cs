using ServiceStack.DataAnnotations;

namespace Groupr.Core.Models
{
    public class Rsvp : EntityBase
    {
        public int EventId { get; set; }
        public int MemberId { get; set; }

        public int StatusId { get; set; }

        [Ignore]
        public RsvpStatus Status
        {
            get { return (RsvpStatus)StatusId; }
            set { StatusId = (int)value; }
        }
    }
}