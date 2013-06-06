using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class LocationViewModel
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Straße")]
        public string Street { get; set; }

        [Required]
        [DisplayName("Stadt")]
        public string City { get; set; }

        [Required]
        [DisplayName("PLZ")]
        public string ZipCode { get; set; }

        [Required]
        [DisplayName("URL")]
        public string WebSite { get; set; }

        [Required]
        [DisplayName("Teilnehmer")]
        public int MaxAttendees { get; set; }
    }
}