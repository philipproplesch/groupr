using ServiceStack.DataAnnotations;

namespace Groupr.Core.Membership
{
    public class UserProfile
    {
        [PrimaryKey]
        [AutoIncrement]
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        public string MailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Bio { get; set; }
        public string Website { get; set; }
        public string TwitterHandle { get; set; }
    }
}
