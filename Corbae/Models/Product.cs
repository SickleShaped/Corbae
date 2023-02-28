using System.ComponentModel.DataAnnotations;

namespace Corbae.Models
{
    public class Product
    {
        /// <summary>
        /// Id птовара
        /// </summary>
        public string ProductID { get; set; } = null!;

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Цена товара за единицу
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Количество данного товара на складе
        /// </summary>
        public uint QuantityInStock { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public string Category { get; set; } = null!;

        /// <summary>
        /// Id пользователя, добавившего этот товар
        /// </summary>
        public string UserID { get; set; } = null!;

        /// <summary>
        /// Пользователь, добавивший этот товар
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Заказы, в которых есть этот товар
        /// </summary>
        public List<Order> Orders { get; set; } = new List<Order>();

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        /// <summary>
        /// Корзины, в которых есть этот товар
        /// </summary>
        public List<Cart> Carts { get; set; } = new List<Cart>();

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();


    }
}
