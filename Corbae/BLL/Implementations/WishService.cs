using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.CartExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Exceptions.WishExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
using Corbae.DAL.Models.DTO;
using Corbae.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    public class WishService :IWishService
    {
        
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public WishService(ApiDbContext dbContext, IMapper mapper, IProductService productService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// Получить желаемое по ID пользователя
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        public async Task<List<WishProductReturn>> GetWishProductsByUserId(Guid userID)
        {
           var wishes =  await _dbContext.WishProducts.Where(u => u.UserID == userID).Include(u => u.Product).ToListAsync();


            List<WishProductReturn> wishproducts = new List<WishProductReturn>();

            foreach (var wish in wishes)
            {
                WishProductReturn product = new WishProductReturn();
                product.ProductID = wish.Product.ProductID;
                product.Name = wish.Product.Name;
                product.Description = wish.Product.Description;
                product.Price = wish.Product.Price;
                product.QuantityInStock = wish.Product.QuantityInStock;
                product.Category = wish.Product.Category;
                product.UserID = wish.Product.UserID;
                product.WishProductID = wish.WishProductID;
                
                wishproducts.Add(product);
            }

            return wishproducts;
        }

        /// <summary>
        /// Создать желаемое
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Cart?</returns>
        public async Task Create(Guid userID)
        {
            WishDB wish = new WishDB();
            wish.UserID = userID;

            await _dbContext.Wishes.AddAsync(wish);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Добавить товар в желаемое
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Cart?</returns>
        public async Task AddProductToWish(Guid productID, Guid userID)
        {
            bool notOwn = await CheckDifferencesBetweenID(productID, userID);
            if (notOwn)
            {
                WishProduct wishProduct = new WishProduct();
                wishProduct.ProductID = productID;
                wishProduct.UserID = userID;
                wishProduct.WishProductID = new Guid();
                await _dbContext.WishProducts.AddAsync(wishProduct);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удалить товар из желаемого
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="UserID"></param>
        /// <returns>Task<List<CartProduct>></returns>
        public async Task RemoveProductFromWish(Guid wishProductID, Guid userID)
        {
            var res = await _dbContext.WishProducts.Where(u => u.WishProductID == wishProductID).ExecuteDeleteAsync();
        }

        /// <summary>
        /// проверить ID, чтобы пользователь не мог добавить свой товар в желаемое
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="userID"></param>
        /// <returns>Task<bool></returns>
        /// <exception cref="ProphibitionToAddOwnProductToWishException"></exception>
        /// <exception cref="NoProductWithThatIdException"></exception>
        private async Task<bool> CheckDifferencesBetweenID(Guid productID, Guid userID)
        {
            var product = await _productService.GetById(productID);
            if (product != null)
            {
                if (product.UserID == userID) throw new ProphibitionToAddOwnProductToWishException();
                else return true;
            }
            else throw new NoProductWithThatIdException(productID);
        }
        
    }
}
