using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Membership
{
    [Alias("webpages_Roles")]
    public class UserRole
    {
        [PrimaryKey]
        [AutoIncrement]
        public int RoleId { get; set; }

        [Required]
        [DecimalLength(256)]
        public string RoleName { get; set; }
    }
}