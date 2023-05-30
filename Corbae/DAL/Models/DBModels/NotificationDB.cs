namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля уведомления, получаемого из БД
    /// </summary>
    public class NotificationDB
    {
        public Guid NotificationID { get; set; }

        /// <summary>
        /// Содержание уведомления
        /// </summary>
        public string? Text { get;set; }

        /// <summary>
        /// ID Пользователя, кому пришло уведомление
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Дата появления уведомления
        /// </summary>
        public DateTime NotificationDate { get; set; }

        /// <summary>
        /// Пользователь, которому пришло уведомление
        /// </summary>
        public UserDB? User { get; set; }
    }
}
