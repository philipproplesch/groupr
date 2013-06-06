using Groupr.Core.Models;

namespace Groupr.Core.Repositories.Common
{
    public interface IMessageRepository
    {
        bool SaveMessage(Message message);
    }
}