using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с аутентификацией и авторизацией
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Зарегестрировать пользователя
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <returns>User</returns>
        //Task<User> SignUp(User user);

        /// <summary>
        /// Создать JWT токен
        /// </summary>
        /// <param name="user"> пользователь </param>
        /// <returns>string</returns>
        //string JwtIssue(User user);
    }
}
