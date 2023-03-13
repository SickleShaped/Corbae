using Corbae.BLL.Interfaces;
using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    public class AuthService:IAuthService
    {
        private readonly ApiDbContext _dbContext;

        public AuthService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
