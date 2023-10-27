using Todo.API.Models;

namespace Todo.Tests.Data
{
    public class UserMockData
    {
        private static readonly string _password = BCrypt.Net.BCrypt.HashPassword("test");

        public static UserCredentials GetUserCredentials()
        {
            var user = new UserCredentials
            {
                Username = "test",
                Password = "test"
            };

            return user;
        }

        public static User GetUser()
        {
            var user = new User
            {
                Id = 3,
                Username = "test",
                Password = _password,
                Email = "Test@test.com",
                Name = "User"
            };

            return user;
        }

        public static List<User> GetUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "test",
                    Password = _password,
                    Email = "Test@test.com",
                    Name = "User"
                },
                new User
                {
                    Id = 2,
                    Username = "test2",
                    Password = _password,
                    Email = "Test2@test.com",
                    Name = "User2"
                }
            };

            return users;
        }
    }
}
