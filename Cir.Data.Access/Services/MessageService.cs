using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Services
{
    internal class MessageService:IMessageService
    {

        public string TableName => "Messages";
        private IMessageDataRepository _messageDataRepository; 
        
        public MessageService(IMessageDataRepository messageDataRepository)
        {
            _messageDataRepository = messageDataRepository;
           
        }

        public IEnumerable<MessageData> GetAllNotReceived(string receiver)
        {
            var list=_messageDataRepository.GetAll().Where(c => c.Receiver.ToLower() == receiver.ToLower() && !c.IsReceived).ToList();
            foreach (var message in list)
            {
                message.IsReceived = true;
                _messageDataRepository.Update(message); 
            }
            return list;
        }

        public MessageData Send(MessageData message)
        {
            message.Id = Guid.NewGuid().ToString();
            message.IsReceived = false;
            _messageDataRepository.Add(message);
            return message;
        }
    }
}