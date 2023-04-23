using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.DTO;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер заказов
    /// </summary>
    [ApiController]
    [Route("/api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns>Task<List<Order>></returns>
        [HttpGet("GetAll")]
        public async Task<List<Order>> GetAll()
        {
            return await _orderService.GetAll();
        }

        /// <summary>
        /// Получить заказы по ID пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Task<List<Order>></returns>
        [HttpGet("GetOrdersByCustomerId")]
        public async Task<List<Order>> GetOrdersByCustomerId(Guid userId)
        {
            return await _orderService.GetOrdersByCustomerId(userId);
        }

        /// <summary>
        /// Получить заказы по дате
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Task<List<Order>></returns>
        [HttpGet("GetOrdersByDate")]
        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            var orders = await _orderService.GetOrdersByDate(date);
            return orders;
        }

        /// <summary>
        /// Получить заказ по ID заказа
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns>Task<Order?></returns>
        [HttpGet("GetOrderById")]
        public async Task<Order?> GetOrderById(Guid orderID)
        {
            var order = await _orderService.GetOrderById(orderID);
            return order;
        }

        /// <summary>
        /// Получить данные из таблицы OrderProducts по ID заказа
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        [HttpGet("GetOrderProductsByOrderID")]
        public async Task<List<OrderProduct>> GetOrderProductsByOrderID(Guid orderID)
        {
            var orderProducts = await _orderService.GetOrderProductsByOrderID(orderID);
            return orderProducts;
        }

    }
}
