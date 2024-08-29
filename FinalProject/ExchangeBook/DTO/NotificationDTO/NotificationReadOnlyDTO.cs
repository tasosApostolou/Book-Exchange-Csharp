using ExchangeBook.Data;
using ExchangeBook.DTO.BookDTOs;
using ExchangeBook.DTO.UserDTOs;
using ExchangeBook.models;

namespace ExchangeBook.DTO.NotificationDTO
{
    public class NotificationReadOnlyDTO
    {
        public int Id { get; set; }
        public UserReadOnlyDTO InterestedUser { get; set; }
        public UserReadOnlyDTO User { get; set; }
        public BookReadOnlyDTO Book { get; set; }
        public NotificationType? Type { get; set; }
        public bool isSeen { get; set; }

    }
}
