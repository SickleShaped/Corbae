﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Exceptions.UserExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.Auxiliary_Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с товаром
    /// </summary>
    public class ProductService:IProductService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        /// <summary>
        /// Получить все товары
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<List<Product>> GetAll()
        {
            var products = await _dbContext.Products.AsNoTracking().ProjectTo<Product>(_mapper.ConfigurationProvider).ToListAsync();
            return products;
        }

        /// <summary>
        /// Получить все товары в данного пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllByUser(Guid userid)
        {
            var products = await _dbContext.Products.Where(p=>p.UserID == userid).AsNoTracking().ProjectTo<Product>(_mapper.ConfigurationProvider).ToListAsync();
            return products;
        }

        /// <summary>
        /// Получить товар по id
        /// </summary>
        /// <param name="id">id товара</param>
        /// <returns>Product?</returns>
        public async Task<Product?> GetById(Guid productId)
        {
            return await _dbContext.Products.ProjectTo<Product>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.UserID == productId);
        }

        /// <summary>
        /// Создать товар
        /// </summary>
        /// <param name="product_"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Product</returns>
        public async Task<Product?> Create(ProductToCreate product_, Guid userid)
        {
            var product = _mapper.Map<ProductDB>(product_);

            product.UserID = userid; 

            await _dbContext.Products.AddAsync(product, CancellationToken.None);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            var _product = _mapper.Map<Product>(product);
            return _product;
        }

        /// <summary>
        /// Изменить заказ
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Task</returns>
        public async Task Edit(ProductToCreate product, Guid productID)
        {
            var product_ = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductID == productID, CancellationToken.None);
            if (product_ == null)
            {
                throw new NoProductWithThatIdException(productID);
            }
            product_ = _mapper.Map<ProductDB>(product);

            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }


        /// <summary>
        /// Изменить количество товара на складе
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="QuantityInStock"></param>
        /// <returns>Task</returns>
        public async Task EditQuantityInStock(Guid productID, uint quantityInStock)
        {
            var product_ = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductID == productID, CancellationToken.None);
            if (product_ == null)
            {
                throw new NoProductWithThatIdException(productID);
            }
            product_.QuantityInStock = quantityInStock;
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Уменьшить количество товара на скаде на 1
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        public async Task ReduceQuantityInStockBy(Guid productID, uint count)
        {
            var product_ = await _dbContext.Products.FirstOrDefaultAsync(u => u.ProductID == productID, CancellationToken.None);
            if (product_ == null)
            {
                throw new NoProductWithThatIdException(productID);
            }
            product_.QuantityInStock -= count;
            await _dbContext.SaveChangesAsync(CancellationToken.None);
        }

        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="product"> товар </param>
        /// <param name="user"> пользователь </param>
        /// <returns>Task</returns>
        public async Task Delete(Guid productID)
        {
            var res = await _dbContext.Products.Where(u => u.ProductID == productID).ExecuteDeleteAsync(CancellationToken.None);
            if (res == 0)
            {
                throw new NoProductWithThatIdException(productID);
            }
        }

        /// <summary>
        /// Удалить все товары данного пользователя
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task DeleteAllByUser(Guid userid)
        {
            await _dbContext.Products.Where(u => u.UserID == userid).ExecuteDeleteAsync(CancellationToken.None);
        }
    }
}
