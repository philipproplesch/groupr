using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace Groupr.Core.Membership
{
    [Alias("webpages_Membership")]
    public class UserMembership
    {
        [PrimaryKey]
        public int UserId { get; set; }

        public DateTime? CreateDate { get; set; }

        [DecimalLength(128)]
        public string ConfirmationToken { get; set; }

        public bool IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }

        [Required]
        public int? PasswordFailuresSinceLastSuccess { get; set; }

        [Required]
        [DecimalLength(128)]
        public string Password { get; set; }

        public DateTime? PasswordChangedDate { get; set; }

        [Required]
        [DecimalLength(128)]
        public string PasswordSalt { get; set; }

        [DecimalLength(128)]
        public string PasswordVerificationToken { get; set; }

        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}