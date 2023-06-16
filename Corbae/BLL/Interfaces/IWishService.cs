using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.DAL.Models.DTO;
using Corbae.Models;

namespace Corbae.BLL.Interfaces
{
    /// <summary>
    /// Интерфейс, определяющий методы взаимодейвия с желаемым
    /// </summary>
    public interface IWishService
    {

        
        /// <summary>
        /// Получить желаемое по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task<List<WishProductReturn>> GetWishProductsByUserId(Guid userID);

        /// <summary>
        /// Создать желаемое
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task Create(Guid userID);

        /// <summary>
        /// Добавить товар в желаемое
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        Task AddProductToWish(Guid productID, Guid userID);

        /// <summary>
        /// Удалить товар из желаемого
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Cart?</returns>
        Task RemoveProductFromWish(Guid wishProductID, Guid UserID);

        

    }
}
