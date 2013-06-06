using Groupr.Core.Data;
using Groupr.Core.Models;
using Groupr.Core.Repositories.Common;
using ServiceStack.OrmLite;

namespace Groupr.Core.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public bool SaveMessage(Message message)
        {
            using (var connection = Database.Factory.Open())
            {
                connection.Insert(message);
                return connection.GetLastInsertId() > 0;
            }
        }
    }
}