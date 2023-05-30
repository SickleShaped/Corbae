using Corbae.DAL.Models.DTO;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с уведомлениями
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Получить все комментарии от данного пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List<Comment></returns>
        Task<List<Notification>> GetAllByUserID(Guid userID);

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <returns>Comment?</returns>
        Task SendANotification(string text, Guid userID);

        /// <summary>
        /// Удалить комментарий по его ID
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        Task DeleteNotification(Guid notificationID);
    }
}
