using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с аутентификацией и авторизацией
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Войти в аккаунт пользователя
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <returns>Task<IResult</returns>
        Task<string> Login(string email, string password);
        

        /// <summary>
        /// Создать JWT токен
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <returns>string</returns>
        Task<string> JwtIssue(User user);
    }
}
