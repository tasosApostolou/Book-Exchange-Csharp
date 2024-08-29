using AutoMapper;
using ExchangeBook.Data;
using ExchangeBook.DTO.NotificationDTO;
using ExchangeBook.Repositories;
using ExchangeBook.Services.Exceptions;

namespace ExchangeBook.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly ILogger<UserService>? _logger;
        private readonly IMapper? _mapper;
        public NotificationService(IUnitOfWork? unitOfWork, ILogger<UserService>? logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Notification?> CreateNotification(int interestedId, NotificationCreateDTO? notifDTO)
        {
            Notification notification;
            User? interested;
            User? user;
            Book? book;
            IEnumerable<Notification> notifications; ;
            try
            {
                user = await _unitOfWork.UserRepositorty.GetAsync(notifDTO.UserId);
                if(user is null)
                {
                    throw new UserNotFoundException("user not found");
                }
                interested = await _unitOfWork.UserRepositorty.GetAsync(interestedId);
                if (interested is null)
                {
                    throw new UserNotFoundException("user not found");
                }
                book = await _unitOfWork.BookRepository.GetAsync(notifDTO.BookId);
                if (book is null) throw new BookNotFoundException("book not found");
                notification = new Notification()
                {
                    InterestedUser = interested,
                    User = user,
                    Book = book,
                    Type = models.NotificationType.INTEREST,
                    IsSeen = false
                };
                await _unitOfWork.NotificationRepository.AddAsync(notification);
                //notifications = await _unitOfWork.NotificationRepository.GetAllAsync();
                notifications = await _unitOfWork.UserRepositorty.GetUserNotificationsAsync(interestedId);

                foreach (Notification notif in notifications)
                {
                    if (notification.User != null && notif.InterestedUser.Id == user.Id)
                    {
                        Notification notification1 = new Notification()
                        {
                            //InterestedUser = notif.User,
                            //User = await _unitOfWork.UserRepositorty.GetAsync(interestedId),
                            InterestedUser = user,
                            User = interested,
                            Book = notif.Book,
                            Type = models.NotificationType.MATCH,
                            IsSeen = false
                        };
                        Notification notification2 = new Notification()
                        {
                            //InterestedId = interestedId,
                            //User = notif.User,
                            InterestedUser = interested,
                            User = user,
                            Book = book,
                            Type = models.NotificationType.MATCH,
                            IsSeen = false
                        };
                        await _unitOfWork.NotificationRepository.AddAsync(notification1 );
                        await _unitOfWork.NotificationRepository.AddAsync(notification2 );
                        break;
                    }
                }
            }catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
                throw;
            }
            await _unitOfWork.SaveAsync();
            return notification;
        }

        public async Task<Notification?> GetNotificationById(int id)
        {
            Notification? notification;
            try
            {
                notification = await _unitOfWork!.NotificationRepository.GetNotificationWithIncludesAsync(id);
                _logger!.LogInformation("{Message}", "Notificaiton with id: " + id + "was found");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
                throw;
            }
            return notification;
        }


        public async Task<Notification?> NotificationPatchIsSeenStatusAsync(int notificationId, NotificationPatchDTO notificationPatchDTO)
        {
            Notification? existingNotification;
            //Notification? notification = null;
            try
            {
                existingNotification = await _unitOfWork.NotificationRepository.GetAsync(notificationId);
                if (existingNotification == null) return null;

                existingNotification.IsSeen = notificationPatchDTO.isSeen;
                await _unitOfWork.SaveAsync(); 
                _logger!.LogInformation("{Message}", "Notification isSeen status: " + existingNotification + " updated successfully");
            }
            catch (Exception e)
            {
                _logger!.LogError("{Message}{Exception}", e.Message, e.StackTrace);
                throw;
            }
            return existingNotification;
        }
    }
   
}
