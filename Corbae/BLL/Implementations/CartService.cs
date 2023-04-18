using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.CartExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с корзиной
    /// </summary>
    public class CartService:ICartService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CartService(ApiDbContext dbContext, IMapper mapper, IProductService productService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// Получить корзину по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        public async Task<List<CartProduct>> GetCartProductsByUserId(Guid userID)
        {
           return await _dbContext.CartProducts.Where(u => u.UserID == userID).Include(u => u.Product).ToListAsync();
        }

        /// <summary>
        /// Создать корзину
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        public async Task Create(Guid userID)
        {
            CartDB cart = new CartDB();
            cart.UserID=userID;

            await _dbContext.Carts.AddAsync(cart );
            await _dbContext.SaveChangesAsync( );
        }

        /// <summary>
        /// Добавить товар в корзину
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Cart?</returns>
        public async Task AddProductToCart(Guid productID, Guid userID)
        {
            bool notOwn = await CheckDifferencesBetweenID(productID, userID);
            if(notOwn)
            {
                CartProduct cartProduct = new CartProduct();
                cartProduct.ProductID = productID;
                cartProduct.UserID = userID;
                cartProduct.CartProductID = new Guid();
                await _dbContext.CartProducts.AddAsync(cartProduct );
            }
        }

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Task<List<CartProduct>></returns>
        public async Task RemoveProductFromCart(Guid cartProductId, Guid userID)
        {
            var res = await _dbContext.CartProducts.Where(u => u.CartProductID == cartProductId).ExecuteDeleteAsync( );
        }

        /// <summary>
        /// проверить ID, чтобы пользователь не мог добавить свой товар в корзину
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Task<bool></returns>
        /// <exception cref="ProhibitionToAddOwnProductToCartException"></exception>
        /// <exception cref="NoProductWithThatIdException"></exception>
        private async Task<bool> CheckDifferencesBetweenID(Guid productID, Guid userID)
        {
            var product = await _productService.GetById(productID);
            if (product != null)
            {
                if(product.UserID == userID) throw new ProhibitionToAddOwnProductToCartException();
                else return true;
            }
            else throw new NoProductWithThatIdException(productID);
        }
    }
}
