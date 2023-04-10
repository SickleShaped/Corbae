
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с корзиной
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Получить корзину по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task<List<CartProduct>> GetCartProductsByUserId(Guid userID);

        /// <summary>
        /// Создать корзину
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task Create(Guid userID);

        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task<List<CartProduct>> AddProductToCart(Guid productID, Guid userID);

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Cart?</returns>
        Task<List<CartProduct>> RemoveProductFromCart(Guid productID, Guid UserID);


    }
}
