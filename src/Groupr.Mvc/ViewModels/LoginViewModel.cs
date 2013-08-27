using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
