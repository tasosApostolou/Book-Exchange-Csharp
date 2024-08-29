using ExchangeBook.Data;
using ExchangeBook.DTO.NotificationDTO;
using ExchangeBook.models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeBook.Repositories
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetNotificationsByType(NotificationType type);
    }
}
