using WebChat.Models;

namespace WebChat.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task AddUser(User user);

        /* Task UpdateUser(int id, User user);*/
        Task UpdateUser(int id, UpdateUserModel model);

        Task DeleteUser(int id);
    }
}
