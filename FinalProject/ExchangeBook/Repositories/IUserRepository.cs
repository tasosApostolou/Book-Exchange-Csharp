using ExchangeBook.Data;
using ExchangeBook.DTO.UserDTOs;

namespace ExchangeBook.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string username, string password);
        Task<User?> UpdateUserAsync(int userId, User request);
        Task<User?> GetByUsernameAsync(string username);
        Task<UserPersonReadOnlyDTO?> GetUserPersonInfoAsync(string username);
        Task<UserStoreReadOnlyDTO?> GetUserStoreInfoAsync(string username);
        Task<List<Notification>> GetNotificationsByUserIdAsync(int? id);
        Task<List<Notification>> GetUserNotificationsAsync(int? id);

    }
}
