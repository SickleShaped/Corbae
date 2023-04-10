using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля корзины, получаемой из БД 
    /// </summary>
    public class CartDB
    {

        /// <summary>
        /// ID пользователя и корзины
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>]
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        /// <summary>
        /// Пользователь, чья корзина
        /// </summary>
        public UserDB? User { get; set; }
    }
}
