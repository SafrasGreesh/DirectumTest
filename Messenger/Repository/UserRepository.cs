using Messenger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Repository
{
    internal class UserRepository
    {
        Manager manager = new Manager();

        public List<UserDataModel> GetUserById(int userId)
        {
            var commandText = $"select * from dbo.User_Profile where userId = {userId}";
            return manager.SetDataUserTable(commandText);
        }

        public List<UserDataModel> GetUserByName(string name)
        {
            var commandText = $"select * from dbo.User_Profile where name = {name}";
            return manager.SetDataUserTable(commandText);
        }

        public void AddUser(UserDataModel user)
        {
            user = new UserDataModel
            {
                Name = "Акакий",
                Password = "32",
                State = false
            };
            var commandText = $"insert into dbo.User_Profile (Name, Password, State)values({user.Name},{user.Name},{user.State})";
            manager.UpdateDataUserTable(commandText);
        } 

        public void UpdateUser(UserDataModel user)
        {
            

            user = new UserDataModel
            {
                Name = "Акакий",
                Password = "32",
                State = false
            };
            var commandText = $"$\"update dbo.User_Profile set Name = {user.Name}, Password = {user.Password}, State = {user.State}";
            manager.UpdateDataUserTable(commandText);
        }

        public void UpdateUserState(int userId, bool state)
        {
            var commandText = $"$\"update dbo.User_Profile State = {state} where UserId = {userId}";
            manager.UpdateDataUserTable(commandText);
        }
    }
}
