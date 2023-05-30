using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    public class NotificationService: INotificationService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public NotificationService(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все комментарии от данного пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List<Comment></returns>
        public async Task<List<Notification>> GetAllByUserID(Guid userID)
        {
            return new List<Notification>();
        }

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <returns>Comment?</returns>
        public async Task SendANotification(string text, Guid userID)
        {
            Notification notification = new Notification
            {
                NotificationID = new Guid(),
                Text = text,
                UserID = userID
            };
            var notificationDB = _mapper.Map<NotificationDB>(notification);
            await _dbContext.Notifications.AddAsync(notificationDB);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить комментарий по его ID
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        public async Task DeleteNotification(Guid notificationID)
        {
            var result = await _dbContext.Notifications.Where(u => u.NotificationID == notificationID).ExecuteDeleteAsync();
        }
    }
}
