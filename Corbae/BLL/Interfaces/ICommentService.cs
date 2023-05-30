using Corbae.DAL.Models.Auxiliary_Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с комментариями под товарами
    /// </summary>
    public interface ICommentService
    {

        /// <summary>
        /// Получить все комментарии под товаром по его ID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>List<Comment></returns>
        Task<List<Comment>> GetAllByProductID(Guid productID);

        /// <summary>
        /// Получить все комментарии от данного пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List<Comment></returns>
        Task<List<Comment>> GetAllByUserID(Guid userID);

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <param name="productID"></param>
        /// <returns>Comment?</returns>
        Task LeaveAComment(string text, Guid userID, Guid productID);

        /// <summary>
        /// Изменить комментарий
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="text"></param>
        /// <returns>Task</returns>
        Task EditComment(Guid commentID, string text);

        /// <summary>
        /// Удалить комментарий по его ID
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        Task DeleteComment(Guid commentID);

        /// <summary>
        /// Удалить все комментарии от пользователя с указанным ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Task</returns>
        //Task DeleteAllCommentsByUser(Guid userID);

        /// <summary>
        /// Удалить все комментарии под постом с указанным ID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        //Task DeleteAllCommentsByProduct(Guid productID);
        
    }
}
