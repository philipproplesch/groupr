using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Token { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}