using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using WebChat.Models;

namespace WebChat.Repositories
{
    public class MessageRepository : ControllerBase, IMessageRepository
    {
        private readonly ChatContext _context;

        public MessageRepository(ChatContext context)
        {
            _context = context;
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetMessagesForUser(int userId)
        {
            return await _context.Messages
              .Where(m => m.RecipientId == userId)
              .ToListAsync();
        }

        public async Task SendMessage(Message message)
        {
            // установить SenderId перед сохранением
            message.SenderId = GetLoggedUserId();

            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
        public async Task<Message> GetMessageById(int id)
        {
            return await _context.Messages.FindAsync(id);
        }
        private int GetLoggedUserId()
        {
            // вариант с JWT токеном

            var accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var handler = new JwtSecurityTokenHandler();

            var jsonToken = handler.ReadToken(accessToken);

            var tokenS = jsonToken as JwtSecurityToken;

            var userIdClaim = tokenS.Claims.FirstOrDefault(x => x.Type == "id");

            return int.Parse(userIdClaim.Value);


            /*            // вариант через сессию

                        return (int)HttpContext.Session.GetInt32("UserId");*/
        }
    }
}
