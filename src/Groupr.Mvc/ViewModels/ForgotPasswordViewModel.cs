using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("E-Mail")]
        public string MailAddress { get; set; }
    }
}