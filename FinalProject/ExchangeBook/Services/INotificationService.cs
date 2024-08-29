using ExchangeBook.Data;
using ExchangeBook.DTO.NotificationDTO;

namespace ExchangeBook.Services
{
    public interface INotificationService
    {
        Task<Notification?> CreateNotification(int interestedId, NotificationCreateDTO? notifDTO);
        Task<Notification?> GetNotificationById(int id);
    }
}
