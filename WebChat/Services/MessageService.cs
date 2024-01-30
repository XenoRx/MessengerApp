using WebChat.Models;
using WebChat.Repositories;

namespace WebChat.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message> GetMessageById(int id)
        {
            return await _messageRepository.GetMessageById(id);
        }
    }
}
