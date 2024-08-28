using ExchangeBook.Data;
using ExchangeBook.DTO.UserDTOs;
using ExchangeBook.models;

namespace ExchangeBook.DTO.NotificationDTO
{
    public class NotificationReadOnlyDTO
    {
        //public int InterestedId { get; set; }
        //public UserReadOnlyDTO User { get; set; }
        public Book Book { get; set; }
        public NotificationType? Type { get; set; }
        public bool isSeen { get; set; }

    }
}
