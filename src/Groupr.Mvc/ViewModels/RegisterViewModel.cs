using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Groupr.Mvc.Resources;

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
        [Remote("ValidateEmail", "Newsletter", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MailAddressInUse")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [System.Web.Mvc.Compare("Password")]
        public string RetypePassword { get; set; }
    }
}
