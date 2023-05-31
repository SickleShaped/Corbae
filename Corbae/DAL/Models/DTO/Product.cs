using Corbae.DAL.Models.DBModels;
using Corbae.Models;
using System.Text.Json.Serialization;

namespace Corbae.DAL.Models.DTO
{
    /// <summary>
    /// Класс, содержащий поля товара
    /// </summary>
    public class Product
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
    }
}
