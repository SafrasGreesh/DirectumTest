using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Repository
{
    internal class ContactRepository
    {
        Manager manager = new Manager();
        public List<ContactDataModel> GetUserContact(int userId, int contactId)
        {
            var commandText = $"select * from dbo.User_Contact where userId = {userId} and contactId = {contactId}";
            return manager.SetDataContactTable(commandText);
        }

        public List<ContactDataModel> GetUserContacts(int userId)
        {
            var commandText = $"select * from dbo.User_Contact where userId = {userId}";
            return manager.SetDataContactTable(commandText);
        }

        public List<ContactDataModel> SearchUserContacts (int userId, string name)
        {
            var commandText = @$"select cnt.ContactId from dbo.User_Contact cnt 
                join dbo.User_Profile pr on pr.Id = cnt.ContactId 
				where cnt.UserId = {userId} and pr.Name like {name}";
            return manager.SetDataContactTable(commandText);
        }

        public void AddContact(ContactDataModel contact)
        {
            contact = new ContactDataModel
            {
                ContactId = 1,
                LastUpdateTime = new DateTime(2001, 12, 12)
            };
            var commandText = $"insert into dbo.User_Contact (UserId, ContactId, LastUpdateTime)values({contact.ContactId},{contact.LastUpdateTime})";
            manager.UpdateDataContactTable(commandText);
        }

        public void UpdateContact(ContactDataModel contact)
        {
            contact = new ContactDataModel
            {
                ContactId = 1,
                LastUpdateTime = new DateTime(2001, 12, 12)
            };
            var commandText = $"update dbo.User_Contact set ContactId = {contact.ContactId}, LastUpdateTime = {contact.LastUpdateTime}";
            manager.UpdateDataContactTable(commandText);
        }

        public void DeleteContact(int userId, int contactId)
        {
            var commandText = $"delete from dbo.User_Contact where userId = {userId} and contactId = {contactId}";
            manager.UpdateDataContactTable(commandText);
        }
    }
}
