using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.CartExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Exceptions.UserExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.Auxiliary_Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.DAL.Models.DTO;
using Corbae.Exceptions.UserExceptions;
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
        public async Task<List<CartProductReturn>> GetCartProductsByUserId(Guid userID)
        {

                var products = await _dbContext.CartProducts.Where(u => u.UserID == userID).Include(u => u.Product).ToListAsync();

                List<CartProductReturn> cartproducts = new List<CartProductReturn>();

                foreach (var cartproduct in products)
                {
                CartProductReturn product2 = new CartProductReturn();
                    product2.ProductID = cartproduct.Product.ProductID;
                    product2.Name = cartproduct.Product.Name;
                    product2.Description = cartproduct.Product.Description;
                    product2.Price = cartproduct.Product.Price;
                    product2.QuantityInStock = cartproduct.Product.QuantityInStock;
                    product2.Category = cartproduct.Product.Category;
                    product2.UserID = cartproduct.Product.UserID;
                    product2.CartProductID = cartproduct.CartProductID;

                cartproducts.Add(product2);
                }

                return cartproducts;
            

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
            ProductDB? product = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductID == productID);
            if(product == null) { throw new NoProductWithThatIdException(productID); }
            CartDB? cart = await _dbContext.Carts.FirstOrDefaultAsync(u => u.UserID == userID);
            if(cart==null) { throw new CartNotFoundException(); }
                        
            if (notOwn)
            {
                CartProduct cartProduct = new CartProduct();
                cartProduct.ProductID = productID;
                cartProduct.UserID = userID;
                cartProduct.CartProductID = new Guid();
                cartProduct.Product = product;
                cartProduct.Cart = cart;
                await _dbContext.CartProducts.AddAsync(cartProduct);
                await _dbContext.SaveChangesAsync();
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
