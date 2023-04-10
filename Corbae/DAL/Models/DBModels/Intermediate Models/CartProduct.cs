using Corbae.DAL.Models.DBModels;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя вспомогательной таблицы для связи МкМ между таблицами Товара и Корзины
    /// </summary>
    public class CartProduct
    {
        /// <summary>
        /// Ключевое поле для вспомогательной таблицы
        /// </summary>
        public Guid CartProductID { get; set; }

        /// <summary>
        /// ID товара
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// ID Корзины
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public ProductDB? Product { get; set; }

        /// <summary>
        /// Корзина
        /// </summary>
        public CartDB? Cart { get; set; }
        

    }
}
