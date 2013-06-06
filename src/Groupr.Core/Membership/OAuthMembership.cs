using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Membership
{
    [Alias("webpages_OAuthMembership")]
    public class OAuthUserMembership
    {
        [PrimaryKey]
        [DecimalLength(30)]
        public string Provider { get; set; }

        [Required]
        [DecimalLength(128)]
        public string ProviderUserId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}