using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Corbae.DAL.Models.DBModels;

namespace Corbae.Models
{
    /// <summary>
    /// Класс, содержащий поля корзины
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Пользователь, к которому принадлежит корзина
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Суммарная цена товаров в корзине
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();
    }
}
