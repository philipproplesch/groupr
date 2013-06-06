using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Vorname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nachname")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Passwort")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DisplayName("Passwort wiederholen")]
        public string RetypePassword { get; set; }
    }
}
