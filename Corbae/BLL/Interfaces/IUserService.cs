using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;

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
        Task<List<UserDB>> GetAll();

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>пользователь</returns>
        Task<UserDB?> GetById(Guid id);

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        /// <param name="name">email пользователя</param>
        /// <returns>пользователь</returns>
        Task<UserDB?> GetByEmail(string email);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">ппользователь</param>
        /// <returns>Id Пользователь</returns>
        Task<Guid> Create(UserDB user);

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
