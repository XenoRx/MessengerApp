using global::WebChat.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using WebChat.Controllers;
using WebChat.Models;
using WebChat.Repositories;
namespace WebChat.UnitTests
{

    namespace WebChat.Tests.Controllers
    {
        [TestFixture]
        public class MessagesControllerTests
        {
            [Test]
            public async Task GetMessages_ReturnsOkResultWithMessages()
            {
                // Arrange
                int userId = 01;
                var mockAuthService = new Mock<AuthenticationService>();
                mockAuthService.Setup(auth => auth.GetCurrentUserId()).Returns(userId);

                var mockMessageRepository = new Mock<IMessageRepository>();
                var fakeMessages = new List<Message> { new Message(), new Message() };
                mockMessageRepository.Setup(repo => repo.GetMessagesForUser(userId)).ReturnsAsync(fakeMessages);

                var controller = new MessagesController(mockMessageRepository.Object, mockAuthService.Object);

                // Act
                var result = await controller.GetMessages();

                // Assert

                ClassicAssert.IsInstanceOf<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                ClassicAssert.IsNotNull(okResult);

                var messages = okResult.Value as List<Message>;
                ClassicAssert.IsNotNull(messages);
                ClassicAssert.AreEqual(fakeMessages.Count, messages.Count);
            }

            [Test]
            public async Task SendMessage_ReturnsOkResult()
            {
                // Arrange
                var mockAuthService = new Mock<AuthenticationService>();
                var mockMessageRepository = new Mock<IMessageRepository>();
                var controller = new MessagesController(mockMessageRepository.Object, mockAuthService.Object);

                // Act
                var result = await controller.SendMessage(new Message());

                // Assert
                ClassicAssert.IsInstanceOf<OkResult>(result);
            }
        }
    }

}

