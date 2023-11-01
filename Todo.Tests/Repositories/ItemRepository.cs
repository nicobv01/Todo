using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Todo.API.Data;
using Todo.API.Repositories;
using Todo.Tests.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Http;

namespace Todo.Tests.Repositories
{
    public class ItemRepositoryTest : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IItemRepository _itemRepository;

        public ItemRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TodoList" + Guid.NewGuid())
                .Options;

            _context = new AppDbContext(options);

            _context.Users.AddRange(UserMockData.GetUsers());
            _context.Items.AddRange(ItemMockData.GetItems());
            _context.SaveChanges();

            _itemRepository = new ItemRepository(_context, new UserContextFake());
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task Insert_ValidItem_ShouldSucceed()
        {
            // Arrange
            var item = ItemMockData.GetItem();

            // Act
            var result = await _itemRepository.Insert(item);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Insert_InvalidItem_ShouldFail()
        {
            // Arrange
            var item = ItemMockData.GetItem();

            // Act
            var result = await _itemRepository.Insert(null);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task CompleteTask_ShouldSucceed()
        {
            // Arrange
            var item = ItemMockData.GetItemById(1);

            // Act
            var result = await _itemRepository.CompleteTask(item.Id);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task CompleteTask_InvalidItem_ShouldFail()
        {
            // Act
            var result = await _itemRepository.CompleteTask(0);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task GetTaskWithCorrectIDShouldRetornTask()
        {
            // Arrange
            var item_id = 1;

            // Act
            var result = await _itemRepository.GetTask(item_id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(item_id);
        }

        [Fact]
        public async Task GetTaskWithWrongIDShouldRetornNull()
        {
            // Arrange
            var item_id = 0;

            // Act
            var result = await _itemRepository.GetTask(item_id);

            // Assert
            result.Should().BeNull();
        }

    }
}