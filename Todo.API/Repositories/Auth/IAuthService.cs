using Todo.API.Models;

namespace Todo.API.Repositories
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}
