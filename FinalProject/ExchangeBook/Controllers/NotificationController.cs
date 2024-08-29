using AutoMapper;
using ExchangeBook.Data;
using ExchangeBook.DTO.BookDTOs;
using ExchangeBook.DTO.NotificationDTO;
using ExchangeBook.DTO.UserDTOs;
using ExchangeBook.Services;
using ExchangeBook.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeBook.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly IMapper _mapper;
        public NotificationController(IApplicationService applicationService, IMapper mapper) : base(applicationService)
        {
            _mapper = mapper;
        }
 
        [HttpPost("{interestedId}")]
        public async Task<ActionResult<NotificationReadOnlyDTO>> CreateNotification(int interestedId, [FromBody] NotificationCreateDTO notificationDto)
        {
            var notification = await _applicationService.NotificationService.CreateNotification(interestedId, notificationDto);
            var returnedNotificationDTO = _mapper.Map<NotificationReadOnlyDTO>(notification);
            //return CreatedAtAction(nameof(GetNotification), new { id = notification.Id }, returnedNotificationDTO);
            return Ok(returnedNotificationDTO);
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<Notification>>> GetUserNotifications(int id)
        //{
        //    List<Notification> notifications = await _applicationService.UserService.GetUserNotificationsAsync(id);
        //    if (notifications is null)
        //    {
        //        throw new NotificationsNotFoundException("not found notifications");
        //    }
        //    return Ok(_mapper.Map<List<NotificationReadOnlyDTO>>(notifications));
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationReadOnlyDTO>> GetNotification(int id)
        {
            Notification? notification = await _applicationService.NotificationService.GetNotificationById(id);
            if (notification is null)
            {
                throw new BookNotFoundException("Notification NotFound");
            }

            NotificationReadOnlyDTO returnedNotification = _mapper.Map<NotificationReadOnlyDTO>(notification);

            return Ok(returnedNotification);
        }


        [HttpPatch("{notificationId}")]
        public async Task<ActionResult<NotificationReadOnlyDTO>> NotificationPatch(int notificationId, NotificationPatchDTO patchDTO)
        {

            var notification = await _applicationService.NotificationService.NotificationPatchIsSeenStatusAsync(notificationId, patchDTO);
            var notificationDTO = _mapper.Map<NotificationReadOnlyDTO>(notification);
            return Ok(notificationDTO);
        }
    }
}
