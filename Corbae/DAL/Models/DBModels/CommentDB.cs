using System.Text.Json.Serialization;

namespace Corbae.DAL.Models.DBModels
{
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

        public Guid UserID { get; set; }

        /// <summary>
        /// Пользователь, оставивший этот коментарий
        /// </summary>
        public UserDB? User { get; set; }
    }
}
