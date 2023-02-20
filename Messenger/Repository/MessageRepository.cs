using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Messenger.Repository
{
    internal class MessageRepository
    {
        Manager manager = new Manager();

        public List<MessageDataModel> GetUserMessages(int userId)
        {
            var commandText = $"select * from dbo.User_Message where userId = {userId}";
            return manager.SetDataMessageTable(commandText);
        }

        public void AddMesage(MessageDataModel messageDataModel)
        {
            messageDataModel = new MessageDataModel
            {
                UserId = 10,
                ContactId = 3,
                SendTime= DateTime.Now,
                DeliveryTime= DateTime.Now,
                Content = "312312312312312312312"
            };
            var commandText = $"insert into dbo.User_Contact (UserId, ContactId, SendTime, DeliveryTime, Content)values({messageDataModel.UserId},{messageDataModel.ContactId}," +
                $" {messageDataModel.SendTime}, {messageDataModel.DeliveryTime}, {messageDataModel.Content})";
            manager.UpdateDataMessageTable(commandText);
        }

        public List<MessageDataModel> SearchUserMessage(int userId, int contactId, string query)
        {
            var commandText = @$"select * from dbo.User_Messages
				where UserId = {userId} and ContactId = {contactId} and Content like {query}";
            return manager.SetDataMessageTable(commandText);
        }
    }
}
