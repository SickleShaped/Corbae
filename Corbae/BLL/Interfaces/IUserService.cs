using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.DAL.Models.Auxiliary_Models;

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
        /// <returns><List<User>></returns>
        Task<List<User>> GetAll();

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>User?</returns>
        Task<User?> GetById(Guid id);

        /// <summary>
        /// Получить пользователя по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        Task<User?> GetByPhoneNumber(string phoneNumber);

        /// <summary>
        /// Получить пользователя по email
        /// </summary>
        /// <param name="name">email пользователя</param>
        /// <returns>User?</returns>
        Task<User?> GetByEmail(string email);

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="user">ппользователь</param>
        /// <returns>Guid</returns>
        Task<Guid> Create(User user);

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="userData">Измененные данные пользователя</param>
        /// <param name="user">пользователь</param>
        /// <returns>User?</returns>
        Task Edit(UserToEdit userData, Guid id);



        /// <summary>
        /// Дать пользователю полномочия админа
        /// </summary>
        /// <param name="id"></param>
        /// <returns>void</returns>
        Task AddAdminCapability(Guid id);

        /// <summary>
        /// Увеличить значение денег пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns>void</returns>
        void AddMoney(Guid id, int amount);

        /// <summary>
        /// Вычесть деньги с баланса пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns>void</returns>
        void ReduceMoney(Guid id, int amount);

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>void</returns>
        Task Delete(Guid id);
    }
}
