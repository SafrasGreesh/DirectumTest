using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Messenger.Services
{
    public class Manager
    {

        private const string connString = @"Server=localhost;Database=Directum;Trusted_Connection=True;";

        public List<ContactDataModel> SetDataContactTable(string commandText)
        {

            List<ContactDataModel> contacts = new List<ContactDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                command.CommandTimeout = 300;
                var sqlRes = command.ExecuteReader();
                while (sqlRes.Read())
                {
                    var contact = new ContactDataModel();
                    contact.UserId = (int)sqlRes.GetValue(0);
                    contact.ContactId = (int)sqlRes.GetValue(1);
                    contact.LastUpdateTime = (DateTime)sqlRes.GetValue(2);
                    contacts.Add(contact);
                    
                }
                sqlRes.Close();
            }
            return contacts; 
        }

        public List<ContactDataModel> UpdateDataContactTable(string commandText)
        {
            List<ContactDataModel> contacts = new List<ContactDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                var sqlRes = command.ExecuteNonQuery();
                
            }
            return contacts;
        }

        public List<UserDataModel> SetDataUserTable(string commandText)
        {

            List<UserDataModel> users = new List<UserDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                command.CommandTimeout = 300;
                var sqlRes = command.ExecuteReader();
                while (sqlRes.Read())
                {
                    var user = new UserDataModel();
                    user.Id = (int)sqlRes.GetValue(0);
                    user.Name= (string)sqlRes.GetValue(1);
                    user.Password = (string)sqlRes.GetValue(2);
                    user.State = (bool)sqlRes.GetValue(3);
                    users.Add(user);

                }
                sqlRes.Close();
            }
            return users;
        }

        public List<UserDataModel> UpdateDataUserTable(string commandText)
        {
            List<UserDataModel> users = new List<UserDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                var sqlRes = command.ExecuteNonQuery();

            }
            return users;
        }

        public List<MessageDataModel> SetDataMessageTable(string commandText)
        {

            List<MessageDataModel> messages = new List<MessageDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                command.CommandTimeout = 300;
                var sqlRes = command.ExecuteReader();
                while (sqlRes.Read())
                {
                    var message = new MessageDataModel();
                    message.UserId = (int)sqlRes.GetValue(0);
                    message.ContactId = (int)sqlRes.GetValue(1);
                    message.SendTime = (DateTime)sqlRes.GetValue(2);
                    message.DeliveryTime = (DateTime)sqlRes.GetValue(3);
                    message.Content = (string)sqlRes.GetValue(4);
                    messages.Add(message);

                }
                sqlRes.Close();
            }
            return messages;
        }

        public List<MessageDataModel> UpdateDataMessageTable(string commandText)
        {
            List<MessageDataModel> messages = new List<MessageDataModel>();

            SqlConnection conn = new SqlConnection(connString);

            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = commandText;
                var sqlRes = command.ExecuteNonQuery();

            }
            return messages;
        }
    }
}
