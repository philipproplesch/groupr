using System;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class MeetingViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        public int LocationId { get; set; }

        [Required]
        public string SpeakerName { get; set; }

        [Required]
        [RegularExpression(@"^http(s)?://(www.)?.+")]
        public string SpeakerWebSite { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ExternalRegistration { get; set; }
    }
}