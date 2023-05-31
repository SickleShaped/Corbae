using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер уведомлений
    /// </summary>
    [ApiController]
    [Route("/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Получить все комментарии от данного пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List<Comment></returns>
        [HttpGet("GetAllByUserID")]
        [Authorize]
        public async Task<List<Notification>> GetAllByUserID(Guid userID)
        {
            var notifications = await _notificationService.GetAllByUserID(userID);
            return notifications;
        }

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <returns>Comment?</returns>
        [HttpPost("SendANotification")]
        [Authorize]
        public async Task SendANotification(string text, Guid userID)
        {
            await _notificationService.SendANotification(text, userID);
        }

        /// <summary>
        /// Удалить комментарий по его ID
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteNotification")]
        [Authorize]
        public async Task DeleteNotification(Guid notificationID)
        {
            await _notificationService.DeleteNotification(notificationID);
        }
    }
}
