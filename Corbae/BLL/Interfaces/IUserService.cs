using Corbae.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns>Пользователи</returns>
        Task<List<User>> GetAll();

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>пользователь</returns>
        Task<User?> GetById(Guid id);

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        /// <param name="name">email пользователя</param>
        /// <returns>пользователь</returns>
        Task<User?> GetByEmail(string email);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">ппользователь</param>
        /// <returns>Id Пользователь</returns>
        Task<Guid> Create(User user);

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="userData">Измененные данные пользователя</param>
        /// <param name="user">пользователь</param>
        /// <returns>Пользователь</returns>
        //Task<User?> Edit(User userData, User user);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>true</returns>
        void Delete(Guid id, string password);
    }
}
