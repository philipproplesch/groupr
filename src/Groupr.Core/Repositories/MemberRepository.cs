using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Groupr.Core.Data;
using Groupr.Core.Membership;
using Groupr.Core.Repositories.Common;
using Groupr.Core.Security;
using ServiceStack.OrmLite;
using WebMatrix.WebData;

namespace Groupr.Core.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public UserProfile OptIn(string token)
        {
            if (WebSecurity.ConfirmAccount(token))
            {
                using (var connection = Database.Factory.Open())
                {
                    var user =
                        connection.FirstOrDefault<UserMembership>(
                            u => u.ConfirmationToken == token);

                    if (user != null)
                    {
                        var profile =
                            connection.GetById<UserProfile>(user.UserId);

                        if (profile != null)
                        {
                            if (!Roles.IsUserInRole(
                                    profile.MailAddress,
                                    WebRoles.Member))
                            {
                                Roles.AddUserToRole(
                                    profile.MailAddress,
                                    WebRoles.Member);

                                return profile;
                            }
                        }
                    }
                }
            }

            return null;
        }

        public UserProfile OptOut(string token)
        {
            using (var connection = Database.Factory.Open())
            {
                var user =
                    connection.FirstOrDefault<UserMembership>(
                        u => u.ConfirmationToken == token);

                if (user != null)
                {
                    var profile =
                        connection.GetById<UserProfile>(user.UserId);

                    if (profile != null && 
                        Roles.IsUserInRole(
                            profile.MailAddress,
                            WebRoles.Member))
                    {
                        Roles.RemoveUserFromRole(
                            profile.MailAddress,
                            WebRoles.Member);

                        return profile;
                    }
                }
            }

            return null;
        }

        public List<UserProfile> GetUsers()
        {
            var result = new List<UserProfile>();

            using (var connection = Database.Factory.Open())
            {
                var users = connection.Select<UserMembership>(u => u.IsConfirmed);

                result.AddRange(
                    users
                        .Select(
                            user => connection.GetById<UserProfile>(user.UserId))
                        .Where(
                            profile => profile != null));
            }

            return result;
        }
    }
}