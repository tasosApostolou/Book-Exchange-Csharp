using ExchangeBook.Data;
using ExchangeBook.DTO.BookDTOs;
using ExchangeBook.DTO.StoreDTO;
using ExchangeBook.models;

namespace ExchangeBook.DTO.NotificationDTO
{
    public class NotificationCreateDTO
    {
        public NotificationType? Type { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
