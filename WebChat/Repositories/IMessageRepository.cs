using WebChat.Models;

namespace WebChat.Repositories
{
    public interface IMessageRepository
    {
        Task SendMessage(Message message);
        Task<Message> GetMessageById(int id);

        Task<IEnumerable<Message>> GetMessagesForUser(int userId);

    }
}
