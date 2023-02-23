﻿using Corbae.Models;

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
        /// <returns>Заказы</returns>
        //List<Order> GetAll();

        /// <summary>
        /// Получить заказы по id пользователя
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns>Заказы</returns>
        //List<Order> GetOrdersByCustomerId(string userId);

        /// <summary>
        /// Получить заказы по дате
        /// </summary>
        /// <param name="date">Дата заказа</param>
        /// <returns>Заказы</returns>
        //List<Order> GetOrdersByDate(DateTime date);

        /// <summary>
        /// Сделать заказ
        /// </summary>
        /// <returns>Заказ</returns>
        //Task<Order?> MakeAnOrder();
    }
}
