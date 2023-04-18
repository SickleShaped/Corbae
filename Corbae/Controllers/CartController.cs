using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер корзины
    /// </summary>
    [ApiController]
    [Route("/api/cart")]
    public class CartController:Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        /// <summary>
        /// Получить корзину по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        [HttpGet("GetCartProductsByUserId")]
        public async Task<List<CartProduct>> GetCartProductsByUserId(Guid userID)
        {
            var cartproducts = await _cartService.GetCartProductsByUserId(userID);
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
            await _cartService.Create(userID);
        }

        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        [HttpPost("AddProductToCart")]
        public async Task AddProductToCart(Guid productID, Guid userID)
        {
            await _cartService.AddProductToCart(productID, userID);
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Cart?</returns>
        [HttpDelete("RemoveProductFromCart")]
        public async Task RemoveProductFromCart(Guid productID, Guid userID)
        {
            await _cartService.RemoveProductFromCart(productID, userID);
        }


    }
}
