using System;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Models
{
    public class Meeting : EntityBase
    {
        public string Name { get; set; }

        public string Abstract { get; set; }

        [References(typeof(Location))]
        public int LocationId { get; set; }
        
        public string SpeakerName { get; set; }
        public string SpeakerWebSite { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ExternalRegistration { get; set; }
    }
}