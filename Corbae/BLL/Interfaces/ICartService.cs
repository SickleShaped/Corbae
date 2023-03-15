
using Corbae.DAL.Models.DBModels;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с корзиной
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Получить корзину по id юзера
        /// </summary>
        /// <param name="userID">id пользователя</param>
        /// <returns>Cart</returns>
        //Task<Cart?> GetCartByUserID(string userID);

        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="cart">Корзина</param>
        /// <param name="product">Товар</param>
        /// <returns>Cart</returns>
        //Task<Cart?> AddToCart(Cart cart, Product product);

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="cart">Корзина</param>
        /// <param name="product">Товар</param>
        /// <returns>Cart</returns>
        //Task<Cart?> RemoveFromCart(Cart cart, Product product);
    }
}
