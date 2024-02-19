using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using WebChat.Controllers;
using WebChat.Models;
using WebChat.Repositories;

namespace WebChat.Tests.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        [Test]
        public async Task GetUser_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            int userId = 1;
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(new User { Id = userId });

            var controller = new UsersController(mockUserRepository.Object);

            // Act
            var result = await controller.GetUser(userId);

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult);

            var user = okResult.Value as User;
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual(userId, user.Id);
        }

        [Test]
        public async Task RegisterUser_ReturnsOkResult_WhenUserIsRegistered()
        {
            // Arrange
            var userModel = new RegisterUserModel { Email = "test@example.com" };
            var mockUserRepository = new Mock<IUserRepository>();
            var controller = new UsersController(mockUserRepository.Object);

            // Act
            var result = await controller.RegisterUser(userModel);

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult);

            var user = okResult.Value as User;
            ClassicAssert.IsNotNull(user);
            ClassicAssert.AreEqual(userModel.Email, user.Email);
        }
    }
}
