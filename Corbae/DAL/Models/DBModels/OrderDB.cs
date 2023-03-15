using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    public class OrderDB
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
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Место доставки заказа
        /// </summary>
        public string DeliveryPlace { get; set; } = null!;

        /// <summary>
        /// Пользователь, совершивший заказ
        /// </summary>
        public UserDB? User { get; set; }

        /// <summary>
        /// Id пользователя, совершающего этот заказ
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Продукты, содержащиеся в заказе
        /// </summary>
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
