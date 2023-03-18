using Corbae.DAL.Models.DBModels;

namespace Corbae.DAL.Models.DTO
{
    /// <summary>
    /// Класс, содержащий поля комментария
    /// </summary>
    public class Comment
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
       /// ID пользователя, оставившего этот комментарий
       /// </summary>
        public Guid UserID { get; set; }
    }
}
