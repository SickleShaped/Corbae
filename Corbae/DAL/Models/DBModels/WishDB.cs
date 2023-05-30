using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.Models;

namespace Corbae.DAL.Models.DBModels
{
    /// <summary>
    /// Класс, содержащий поля папки желаемое, получаемой из БД 
    /// </summary>
    public class WishDB
    {
        /// <summary>
        /// ID пользователя и корзины
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Суммарная цена товаров в корзине
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Продукты, содержащиеся в корзине
        /// </summary>]
        public List<ProductDB> Products { get; set; } = new List<ProductDB>();

        /// <summary>
        /// Вспомогательное поле для связи МкМ
        /// </summary>
        public List<WishProduct> WishProducts { get; set; } = new List<WishProduct>();

        /// <summary>
        /// Пользователь, чья корзина
        /// </summary>
        public UserDB? User { get; set; }
    }
}
