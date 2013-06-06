using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Membership
{
    [Alias("webpages_UsersInRoles")]
    public class UsersInRoles
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        [References(typeof(UserMembership))]
        public int UserId { get; set; }

        [Required]
        [References(typeof(UserRole))]
        public int RoleId { get; set; }
    }
}
