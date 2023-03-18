using System.ComponentModel.DataAnnotations;
using Corbae.DAL.Models.DBModels;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя вспомогательной таблицы для связи МкМ между таблицами Товара и Заказа
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Ключевое поле для вспомогательной таблицы
        /// </summary>
        public Guid OrderProductID { get; set; }

        /// <summary>
        /// ID Заказа
        /// </summary>
        public Guid OrderID { get; set; }

        /// <summary>
        /// ID Товара
        /// </summary>
        public Guid ProductID { get; set; }

        [JsonIgnore]
        public OrderDB? Order { get; set; }

        [JsonIgnore]
        public ProductDB? Product { get;set; }

    }
}
