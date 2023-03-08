using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Corbae.Models
{
    public class Cart
    {
        /// <summary>
        /// Id Корзины
        /// </summary>
        public Guid CartID { get; set; }

        /// <summary>
        /// Пользователь, к которому принадлежит корзина
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();

        [JsonIgnore]
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        


    }
}
