using System.Collections.Generic;
using Groupr.Core.Membership;

namespace Groupr.Core.Repositories.Common
{
    public interface IMemberRepository
    {
        UserProfile OptIn(string token);
        UserProfile OptOut(string token);
        List<UserProfile> GetUsers();
        List<UserProfile> GetLeaders();
        UserProfile GetMemberByUserName(string userName);
        UserProfile GetMemberByHash(string hash);
    }
}
