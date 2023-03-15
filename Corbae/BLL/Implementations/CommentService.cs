using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    public class CommentService
    {
        private readonly ApiDbContext _dbContext;

        public CommentService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
