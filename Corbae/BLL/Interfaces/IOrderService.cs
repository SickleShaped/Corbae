using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        List<Order> GetOrdersByCustomerId(string userId);
        List<Order> GetOrdersByDate(DateTime date);
        Task<Order?> MakeAnOrder();
    }
}
