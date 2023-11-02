using Todo.API.Controllers;
using Todo.API.Models;
using Todo.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;
using Todo.Tests.Data;

namespace Todo.Tests.Controllers
{
    public class ItemControllerTest
    {
        [Fact]
        public async Task Post_ShouldReturn200StatusAsync()
        {
            // Arrange
            var item = ItemMockData.GetItem();
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.Insert(item).Returns(true);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.Post(item);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<CreatedAtActionResult>()
               .Which.StatusCode.Should().Be(201);
        }

        [Fact]
        public async Task Post_ShouldReturn400StatusAsync()
        {
            // Arrange
            var item = ItemMockData.GetItem();
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.Insert(item).Returns(false);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.Post(item);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<BadRequestResult>()
               .Which.StatusCode.Should().Be(400);
        }

        [Fact]
        public async Task CompleteTask_ShouldReturn200StatusAsync()
        {
            // Arrange
            var item = ItemMockData.GetItemById(1);
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.CompleteTask(item.Id).Returns(true);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.CompleteTask(item.Id);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<OkResult>()
               .Which.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CompleteTask_ShouldReturn404StatusAsync()
        {
            // Arrange
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.CompleteTask(0).Returns(false);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.CompleteTask(0);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<NotFoundResult>()
               .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task CompleteTask_WithInvalidUserId_ShouldReturn404StatusAsync()
        {
            // Arrange
            var item = ItemMockData.GetItemById(1);
            item.UserId = 2;
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.CompleteTask(item.Id).Returns(false);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.CompleteTask(item.Id);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<NotFoundResult>()
               .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetTask_WithCorrectID_ShouldReturn200StatusAsync()
        {
            // Arrange
            var item_id = 1;
            var item = ItemMockData.GetItemById(item_id);
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.GetTask(item_id).Returns(item);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.GetById(item_id);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<OkObjectResult>()
               .Which.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetTask_WithInvalidID_ShouldReturn404StatusAsync()
        {
            // Arrange
            var item_id = 0;
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.GetTask(item_id).Returns((Item)null);
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.GetById(item_id);

            // Assert
            result.Should().BeOfType<ActionResult<Item>>();
            result.As<ActionResult<Item>>().Result.Should().BeOfType<NotFoundResult>()
               .Which.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task GetAllTaksOfOneUser_ShouldReturn200StatusCodeAsync()
        {
            // Arrange
            var item = ItemMockData.GetItem();
            var taskRepository = Substitute.For<IItemRepository>();
            taskRepository.GetTasks().Returns(new List<Item> { item });
            var controller = new ItemsController(taskRepository);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<ActionResult<IEnumerable<Item>>>();
            result.As<ActionResult<IEnumerable<Item>>>().Result.Should().BeOfType<OkObjectResult>()
               .Which.StatusCode.Should().Be(200);
        }
    }
}
