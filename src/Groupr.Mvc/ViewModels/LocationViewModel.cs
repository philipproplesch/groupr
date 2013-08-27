using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class LocationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public int MaxAttendees { get; set; }
    }
}