﻿using Corbae.DAL.Models.DBModels;
using Corbae.Models;
using System.Text.Json.Serialization;

namespace Corbae.DAL.Models.DTO
{
    public class Order
    {
        /// <summary>
        /// Id Заказа
        /// </summary>
        public Guid OrderID { get; set; }

        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Дата Доставки заказа
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Место доставки заказа
        /// </summary>
        public string DeliveryPlace { get; set; } = null!;

        /// <summary>
        /// Id пользователя, совершающего этот заказ
        /// </summary>
        public Guid UserID { get; set; }
    }
}
