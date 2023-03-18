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
        /// Id Корзины
        /// </summary>
        public Guid CartID { get; set; }

        /// <summary>
        /// Пользователь, к которому принадлежит корзина
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
        /// Пользователь, оставивший этот комментарий
        /// </summary>
        public UserDB? User { get; set; }
    }
}
