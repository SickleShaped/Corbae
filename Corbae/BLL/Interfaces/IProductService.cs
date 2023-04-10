using Corbae.Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.DAL.Models.Auxiliary_Models;

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
        /// <returns>List<Product></returns>
        Task<List<Product>> GetAll();

        /// <summary>
        /// Получить все товары в данного пользователя
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllByUser(Guid userid);

        /// <summary>
        /// Получить товар по id
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Product?</returns>
        Task<Product?> GetById(Guid id);

        /// <summary>
        /// Создать товар
        /// </summary>
        /// <param name="product"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Product</returns>
        Task<Product?> Create(ProductToCreate product, Guid userid);

        /// <summary>
        /// Изменить заказ
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Task</returns>
        Task Edit(ProductToCreate product, Guid productID);

        /// <summary>
        /// Изменить количество товара на складе
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="QuantityInStock"></param>
        /// <returns>Task</returns>
        Task EditQuantityInStock(Guid productID, uint uantityInStock);

        /// <summary>
        /// Уменьшить количество товара на скаде на 1
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        Task ReduceQuantityInStockBy(Guid productID, uint count);

        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="product"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Task</returns>
        Task Delete(Guid productID);

        /// <summary>
        /// Удалить все товары данного пользователя
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Task DeleteAllByUser(Guid userid);
    }
}
