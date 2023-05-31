using Corbae.DAL.Models.DBModels;

namespace Corbae.DAL.Models.DTO
{
    /// <summary>
    /// Класс, содержащий поля уведомления
    /// </summary>
    public class Notification
    {
        public Guid NotificationID { get; set; }

        /// <summary>
        /// Содержание уведомления
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// ID Пользователя, кому пришло уведомление
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Дата появления уведомления
        /// </summary>
        public DateTime NotificationDate { get; set; }
    }
}
