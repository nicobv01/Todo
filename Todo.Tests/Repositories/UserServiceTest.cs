using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.API.Data;
using Todo.API.Models;
using Todo.API.Repositories.Auth;
using Todo.Tests.Data;
using FluentAssertions;

namespace Todo.Tests.Repositories
{
    public class UserServiceTest : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public UserServiceTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TodoList")
                .Options;

            _context = new AppDbContext(options);

            _context.Tasks.AddRange(ItemMockData.getItems());
            _context.Users.AddRange(UserMockData.GetUsers());
            _context.SaveChanges();

            _authService = new AuthService(_context, _configuration);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task Authenticate_ValidUser_ShouldSucceed()
        {
            // Arrange
            var userCredentials = UserMockData.GetUserCredentials();

            // Act
            var result = _authService.Authenticate(userCredentials.Username, userCredentials.Password);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be(userCredentials.Username);
        }

        [Fact]
        public async Task Authenticate_InvalidUser_ShouldFail()
        {
            // Arrange
            var userCredentials = UserMockData.GetUserCredentials();

            // Act
            var result = _authService.Authenticate(userCredentials.Username, "invalid");

            // Assert
            result.Should().BeNull();
        }
    }
}
