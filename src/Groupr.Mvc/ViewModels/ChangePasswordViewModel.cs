using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Token { get; set; }

        [Required]
        [DisplayName("Neues Passwort")]
        public string NewPassword { get; set; }
    }
}