using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер комментариев
    /// </summary>
    [ApiController]
    [Route("/api/comment")]
    public class CommentController:Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все комментарии под товаром
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task<List<Comment>></returns>
        [HttpGet("GetAllByProductID")]
        public async Task<List<Comment>> GetAllByProductID(Guid productID)
        {
            return await _commentService.GetAllByProductID(productID);
        }

        /// <summary>
        /// Получить все комментарии пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Task<List<Comment>></returns>
        [HttpGet("GetAllByUserID")]
        public async Task<List<Comment>> GetAllByUserID(Guid userID)
        {
            return await _commentService.GetAllByUserID(userID);
        }

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <param name="productID"></param>
        /// <returns>Task<Comment?></returns>
        [HttpPost("LeaveAComment")]
        public async Task<Comment?> LeaveAComment(string text, Guid userID, Guid productID)
        {
            return await _commentService.LeaveAComment(text, userID, productID);
        }

        /// <summary>
        /// Изменить комменнтарий
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="text"></param>
        /// <returns>Task</returns>
        [HttpPut("EditComment")]
        public async Task EditComment(Guid commentID, string text)
        {
            await _commentService.EditComment(commentID, text);
        }

        /// <summary>
        /// Удалить комментарий
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteComment")]
        public async Task DeleteComment(Guid commentID)
        {
            await _commentService.DeleteComment(commentID);
        }

        /// <summary>
        /// Удалить все комментарии пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteAllCommentsByUser")]
        public async Task DeleteAllCommentsByUser(Guid userID)
        {
            await _commentService.DeleteAllCommentsByUser(userID);
        }

        /// <summary>
        /// Удалить все комментарии под товаром
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteAllCommentsByProduct")]
        public async Task DeleteAllCommentsByProduct(Guid productID)
        {
            await _commentService.DeleteAllCommentsByProduct(productID);
        }


    }
}
