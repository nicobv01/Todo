﻿using Todo.API.Controllers;
using Todo.API.Models;
using Todo.Tests.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Todo.API.Repositories;

namespace Todo.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void Authenticate_ShouldReturn200Status()
        {
            // Arrange
            var userCredentials = UserMockData.GetUserCredentials();
            var user = UserMockData.GetUser();
            var authService = Substitute.For<IAuthService>();
            authService.Authenticate(user.Username, user.Password).Returns(user);
            var controller = new AuthController(authService);

            // Act
            var result = controller.Login(userCredentials) as OkObjectResult;

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void Authenticate_ShouldReturn401Status()
        {
            // Arrange
            var userCredentials = UserMockData.GetUserCredentials();
            var authService = Substitute.For<IAuthService>();
            authService.Authenticate(userCredentials.Username, userCredentials.Password).Returns((User)null);
            var controller = new AuthController(authService);

            // Act
            var result = controller.Login(userCredentials) as UnauthorizedResult;

            // Assert
            result.StatusCode.Should().Be(401);
        }
    }
}
