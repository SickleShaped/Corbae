namespace Corbae.DAL.Models.DBModels.Intermediate_Models
{
    /// <summary>
    /// Класс, содержащий поля пользователя вспомогательной таблицы для связи МкМ между таблицами Товара и Желаемого
    /// </summary>
    public class WishProduct
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
        /// Товар
        /// </summary>
        public ProductDB? Product { get; set; }

        /// <summary>
        /// Желаемое
        /// </summary>
        public WishDB? Wish { get; set; }

    }
}
