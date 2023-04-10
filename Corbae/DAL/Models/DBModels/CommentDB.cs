using System.Text.Json.Serialization;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля комментария, получаемого из БД 
    /// </summary>
    public class CommentDB
    {
        /// <summary>
        /// Id Комментария
        /// </summary>
        public Guid CommentID { get; set; }

        /// <summary>
        /// Содержание комментария
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// ID Пользователя, оставивший этот комментарий
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Пользователь, оставивший этот коментарий
        /// </summary>
        public UserDB? User { get; set; }

        /// <summary>
        /// ID товара, под которым оставлен этот комментарий
        /// </summary>
        public Guid ProductID { get; set; }
    }
}
