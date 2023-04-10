namespace Corbae.DAL.Models.Auxiliary_Models
{
    /// <summary>
    /// Класс, содержащий поля товара для создания и изменения товара
    /// </summary>
    public class ProductToCreate
    {
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
    }
}
