using Corbae.Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с товарами
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        /// <returns>Товары</returns>
        Task<List<Product>> GetAll();

        /// <summary>
        /// Получить товар по id
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Товар</returns>
        //Task<Product> GetById(string id);

        /// <summary>
        /// Создать товар
        /// </summary>
        /// <param name="product"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Товар</returns>
        //Task<Product> Create(Product product, User user);

        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="product"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Товар</returns>
        //Task<Product> Delete(Product product, User user);
    }
}
