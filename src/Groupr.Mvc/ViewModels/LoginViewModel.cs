using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Passwort")]
        public string Password { get; set; }
    }
}
