using Corbae.BLL.Interfaces;
using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с аутентификацией
    /// </summary>
    public class AuthService:IAuthService
    {
        private readonly ApiDbContext _dbContext;

        public AuthService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
