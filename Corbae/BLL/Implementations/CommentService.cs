using Corbae.BLL.Interfaces;
using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с коментариями
    /// </summary>
    public class CommentService:ICommentService
    {
        private readonly ApiDbContext _dbContext;

        public CommentService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
