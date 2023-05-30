using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using Corbae.BLL.Enums;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля заказа, получаемого из БД 
    /// </summary>
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
        /// Место доставки заказа
        /// </summary>
        public string DeliveryPlace { get; set; } = null!;

        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatusEnum.Status Status { get; set; }

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

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        //public bool isDeleted { get; set; }

    }
}
