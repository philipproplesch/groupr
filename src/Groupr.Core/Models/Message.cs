using System.ComponentModel.DataAnnotations;

namespace Groupr.Core.Models
{
    public class Message : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string MailAddress { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
