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
        public async Task Post_ShouldReturn200Status()
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
        public async Task Post_ShouldReturn400Status()
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

    }
}
