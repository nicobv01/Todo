using Todo.API.Models;

namespace Todo.API.Repositories.Auth
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}
