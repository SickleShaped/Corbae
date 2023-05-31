using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер комментариев
    /// </summary>
    [ApiController]
    [Route("/comment")]
    public class CommentController:Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
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
        [Authorize]
        public async Task LeaveAComment(string text, Guid userID, Guid productID)
        {
            await _commentService.LeaveAComment(text, userID, productID);
        }

        /// <summary>
        /// Изменить комменнтарий
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="text"></param>
        /// <returns>Task</returns>
        [HttpPut("EditComment")]
        [Authorize]
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
        [Authorize]
        public async Task DeleteComment(Guid commentID)
        {
            await _commentService.DeleteComment(commentID);
        }
    }
}
