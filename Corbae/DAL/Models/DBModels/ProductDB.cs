using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля товара, получаемого из БД 
    /// </summary>
    public class ProductDB
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public Guid ProductID { get; set; }

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
        public string? Category { get; set; }

        /// <summary>
        /// Id пользователя, добавившего этот товар
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Пользователь, добавивший этот товар
        /// </summary>
        public UserDB? User { get; set; }

        /// <summary>
        /// Заказы, в которых есть этот товар
        /// </summary>
        public List<OrderDB> Orders { get; set; } = new List<OrderDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        /// <summary>
        /// Корзины, в которых есть этот товар
        /// </summary>
        public List<CartDB> Carts { get; set; } = new List<CartDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        /// <summary>
        /// Желаемое, в котором есть этот товар
        /// </summary>
        public List<WishDB> Wishes { get; set; } = new List<WishDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<WishProduct> WishProducts { get; set; } = new List<WishProduct>();

        /// <summary>
        /// Комментарии, оставленные под этим товаром
        /// </summary>
        public List<CommentDB> Comments { get; set; } = new List<CommentDB>();


    }
}
