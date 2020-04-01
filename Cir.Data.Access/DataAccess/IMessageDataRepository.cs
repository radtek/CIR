using System.Linq;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.DataAccess
{
    internal interface IMessageDataRepository
    {
        MessageData Get(string id);
        IQueryable<MessageData> GetAll();        
        void Add(MessageData report);
        void Update(MessageData report);
        void Delete(string reportId);
    }
}