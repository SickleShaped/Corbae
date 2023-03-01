using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class Order
    {
        /// <summary>
        /// Id Заказа
        /// </summary>
        public string OrderID { get; set; } = null!;

        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата создания заказа
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата Доставки заказа
        /// </summary>
        public DateTime DeliveryDate { get; set; }

        /// <summary>
        /// Место доставки заказа
        /// </summary>
        public string DeliveryPlace { get; set; } = null!;

        /// <summary>
        /// Пользователь, совершивший заказ
        /// </summary>
        [JsonIgnore]
        public User User { get; set; } = null!;

        /// <summary>
        /// Id пользователя, совершающего этот заказ
        /// </summary>
        public string UserID { get; set; } = null!;

        /// <summary>
        /// Продукты, содержащиеся в заказе
        /// </summary>
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();

        [JsonIgnore]
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
