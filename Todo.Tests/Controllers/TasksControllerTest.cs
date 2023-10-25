using Todo.API.Controllers;
using Todo.API.Models;
using Todo.API.Repositories.Task;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;
using Todo.Tests.Data;

namespace Todo.Tests.Controllers
{
    public class TasksControllerTest
    {
        [Fact]
        public void Post_ShouldReturn200Status()
        {
            // Arrange
            var task = ItemMockData.getItem();
            var taskRepository = Substitute.For<ITaskRepository>();
            taskRepository.Insert(task).Returns(true);
            var controller = new TasksController(taskRepository);

            // Act
            var result = controller.Post(task);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
        }


    }
}
