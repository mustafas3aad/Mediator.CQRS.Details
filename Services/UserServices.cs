using Mediator.CQRS.Interfaces;
using Mediator.CQRS.Models;

namespace Mediator.CQRS.Services
{
    public class UserServices : IUserServices
    {
        private static List<UserModel> _users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new UserModel()
            {
                 Id = 2,
                 FirstName = "Jane",
                 LastName = "Smith"
            },
            new UserModel()
            {
                 Id = 3,
                 FirstName = "Bob",
                 LastName = "Johnson"
            }
        };
        public UserModel AddUser(UserModel user)
        {
            _users.Add(user);
            return user;
        }

        public UserModel GetUserByIndex(int index)
        {
             return _users[index];
        }

        public List<UserModel> GetUsers()
        {
            return _users;
        }
    }
}
