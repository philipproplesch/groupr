using System;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Models
{
    public class Rsvp : EntityBase
    {
        public Guid EventId { get; set; }
        public Guid MemberId { get; set; }

        public int StatusId { get; set; }

        [Ignore]
        public RsvpStatus Status
        {
            get { return (RsvpStatus)StatusId; }
            set { StatusId = (int)value; }
        }
    }
}