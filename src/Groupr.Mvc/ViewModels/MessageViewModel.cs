using System.ComponentModel.DataAnnotations;

namespace Groupr.Mvc.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}
