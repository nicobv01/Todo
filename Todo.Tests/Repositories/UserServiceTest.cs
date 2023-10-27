using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.API.Data;
using Todo.API.Repositories;
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
                .UseInMemoryDatabase(databaseName: "TodoList" + Guid.NewGuid())
                .Options;

            _context = new AppDbContext(options);

            _context.Users.AddRange(UserMockData.GetUsers());
            _context.Items.AddRange(ItemMockData.GetItems());
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

        [Fact]
        public async Task Register_ValidUser_ShouldBeTrue()
        {
            // Arrange
            var user = UserMockData.GetUser();

            // Act
            var result = await _authService.Register(user);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Register_InvalidUser_ShouldBeFalse()
        {
            // Arrange
            var user = UserMockData.GetUser();
            user.Username = null;

            // Act
            var result = await _authService.Register(user);

            // Assert
            result.Should().BeFalse();
        }
    }
}