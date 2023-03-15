using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    public class CartDB
    {
        /// <summary>
        /// Id Корзины
        /// </summary>
        public Guid CartID { get; set; }

        /// <summary>
        /// Пользователь, к которому принадлежит корзина
        /// </summary>
        public UserDB User { get; set; } = null!;

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>]
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();




    }
}
