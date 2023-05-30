using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.DAL.Models.DBModels;

namespace Corbae.DAL.Models.DTO
{
    public class Wish
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
    }
}
