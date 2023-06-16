namespace Corbae.DAL.Models.DBModels.Intermediate_Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя вспомогательной таблицы для связи МкМ между таблицами Товара и Желаемого
    /// </summary>
    public class WishProductReturn
    {
        /// <summary>
        /// Ключевое поле для вспомогательной таблицы
        /// </summary>
        public Guid WishProductID { get; set; }

        /// <summary>
        /// ID товара
        /// </summary>
        public Guid ProductID { get; set; }

        /// <summary>
        /// ID Корзины
        /// </summary>
        public Guid UserID { get; set; }

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
