using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.CommentExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с коментариями
    /// </summary>
    public class CommentService:ICommentService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить все комментарии под товаром по его ID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>List<Comment></returns>
        public async Task<List<Comment>> GetAllByProductID(Guid productID)
        {
            var products = await _dbContext.Comments.Where(p => p.ProductID == productID).AsNoTracking().ProjectTo<Comment>(_mapper.ConfigurationProvider).ToListAsync();
            return products;
        }

        /// <summary>
        /// Получить все комментарии от данного пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>List<Comment></returns>
        public async Task<List<Comment>> GetAllByUserID(Guid userID)
        {
            var products = await _dbContext.Comments.Where(p => p.UserID == userID).AsNoTracking().ProjectTo<Comment>(_mapper.ConfigurationProvider).ToListAsync();
            return products;
        }

        /// <summary>
        /// Оставить комментарий
        /// </summary>
        /// <returns>Comment?</returns>
        public async Task LeaveAComment(string text, Guid userID, Guid productID)
        {
            Comment comment = new Comment();
            comment.Text = text;
            comment.UserID = userID;
            comment.ProductID = productID;

            var commentDB = _mapper.Map<CommentDB>(comment); 
            await _dbContext.Comments.AddAsync(commentDB);
            await _dbContext.SaveChangesAsync( );
        }

        /// <summary>
        /// Изменить комментарий
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        public async Task EditComment(Guid commentID, string text)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(u => u.CommentID == commentID );
            if (comment == null) throw new CommentNotFoundException();
            comment.Text = text;
            await _dbContext.SaveChangesAsync( );
        }

        /// <summary>
        /// Удалить комментарий по его ID
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns>Task</returns>
        public async Task DeleteComment(Guid commentID)
        {
            var res = await _dbContext.Comments.Where(u => u.CommentID == commentID).ExecuteDeleteAsync( );
            if (res == 0) throw new DeleteCommentErrorException();
        }

        /// <summary>
        /// Удалить все комментарии от пользователя с указанным ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Task</returns>
        //public async Task DeleteAllCommentsByUser(Guid userID)
        //{
         //   var res = await _dbContext.Comments.Where(u => u.UserID == userID).ExecuteDeleteAsync( );
       // }

        /// <summary>
        /// Удалить все комментарии под постом с указанным ID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        //public async Task DeleteAllCommentsByProduct(Guid productID)
        //{
        //    var res = await _dbContext.Comments.Where(u => u.ProductID == productID).ExecuteDeleteAsync( );
       // }
    }
}
