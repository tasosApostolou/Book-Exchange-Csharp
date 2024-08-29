using ExchangeBook.Data;
using ExchangeBook.DTO.NotificationDTO;
using ExchangeBook.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExchangeBook.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(BookExchangeDbContext context) : base(context)
        {
        }

        public Task<List<Notification>> GetNotificationsByType(NotificationType type)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Notification>> GetNotificationByInterestedId(int id)
        {
            var notifications = await _context.Notifications
                .Where(n => n.Id == id)
                .Include(n => n.User)
                .Include(n => n.InterestedUser)
                .Include(n => n.Book)
                .ToListAsync();
            return notifications;
        }

        public async Task<Notification> GetNotificationWithIncludesAsync(int notificationId)
        {
            var notification = await _context.Notifications
                .Include(n => n.InterestedUser)
                .Include(n => n.User)
                .Include(n => n.Book)
                .FirstOrDefaultAsync(n => n.Id == notificationId);

            if (notification == null)
            {
                return null;
            }
            return notification;
        }
    }
}
