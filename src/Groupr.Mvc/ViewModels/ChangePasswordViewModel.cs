using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Groupr.Mvc.ViewModels
{
    [ValidateInput(false)]
    public class ChangePasswordViewModel
    {
        public string Token { get; set; }

        [Required]
        [MaxLength(128)]
        public string NewPassword { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword")]

        [MaxLength(128)]
        public string ConfirmNewPassword { get; set; }
    }
}