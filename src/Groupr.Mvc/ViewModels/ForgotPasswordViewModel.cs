using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }
    }
}