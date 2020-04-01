using System.Collections.Generic;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Services
{
    public interface IMessageService
    {        
        IEnumerable<MessageData> GetAllNotReceived(string receiver);
        MessageData Send(MessageData report);
    }
}