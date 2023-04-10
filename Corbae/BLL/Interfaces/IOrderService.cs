using Corbae.Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с заказом/заказами
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns>List<Order></returns>
        Task<List<Order>> GetAll();

        /// <summary>
        /// Получить заказы по id пользователя
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns>List<Order></returns>
        Task<List<Order>> GetOrdersByCustomerId(Guid userId);

        /// <summary>
        /// Получить заказы по дате
        /// </summary>
        /// <param name="date">Дата заказа</param>
        /// <returns>List<Order><Order></returns>
        Task<List<Order>> GetOrdersByDate(DateTime date);

        /// <summary>
        /// Получить заказ по ID
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        Task<Order?> GetOrderById(Guid orderID);

        /// <summary>
        /// Сделать заказ
        /// </summary>
        /// <returns>Order?</returns>
        Task<Order?> MakeAnOrder(List<Guid> productsID, Guid UserId);
    }
}
