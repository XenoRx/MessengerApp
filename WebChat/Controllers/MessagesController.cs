using Microsoft.AspNetCore.Mvc;
using WebChat.Models;
using WebChat.Repositories;
namespace WebChat.Controllers
{
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly Services.AuthenticationService _authenticationService;
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository, Services.AuthenticationService authenticationService)
        {
            _messageRepository = messageRepository;
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            // получаем ID пользователя из JWT токена
            var userId = _authenticationService.GetCurrentUserId();

            var messages = await _messageRepository.GetMessagesForUser(userId);

            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            // получаем ID отправителя из JWT токена
            message.SenderUserId = _authenticationService.GetCurrentUserId();

            await _messageRepository.SendMessage(message);

            return Ok();
        }
    }
}
