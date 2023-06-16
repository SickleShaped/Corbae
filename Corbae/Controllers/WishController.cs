using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.DAL.Models.DTO;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// контроллер желаемого
    /// </summary>
    [ApiController]
    [Route("/wish")]
    public class WishController : Controller
    {
        private readonly IWishService _wishService;

        public WishController(IWishService wishService)
        {
            _wishService = wishService;
        }
        
        /// <summary>
        /// Получить корзину по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        [HttpGet("GetCartProductsByUserId")]
        public async Task<List<WishProductReturn>> GetWishProductsByUserId(Guid userID)
        {
            var cartproducts = await _wishService.GetWishProductsByUserId(userID);
            return cartproducts;
        }

        /// <summary>
        /// Создать корзину
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        [HttpPost("Create")]
        public async Task Create(Guid userID)
        {
            await _wishService.Create(userID);
        }

        /// <summary>
        /// Добавить товар в желаемое
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        [HttpPost("AddProductToCart")]
        public async Task AddProductToWish(Guid productID, Guid userID)
        {
            await _wishService.AddProductToWish(productID, userID);
        }

        /// <summary>
        /// Удалить товар из желаемого
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Cart?</returns>
        [HttpDelete("RemoveProductFromCart")]
        public async Task RemoveProductFromWish(Guid wishProductID, Guid userID)
        {
            await _wishService.RemoveProductFromWish(wishProductID, userID);
        }
    }

}