using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Groupr.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Remote("ValidateEmail", "Newsletter")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string RetypePassword { get; set; }
    }
}
