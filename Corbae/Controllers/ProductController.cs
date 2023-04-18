using AutoMapper;
using Corbae.BLL.Interfaces;
using Corbae.DAL.Models.Auxiliary_Models;
using Corbae.DAL.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер товара
    /// </summary>
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Получить все товары
        /// </summary>
        /// <returns>Task<List<Product>></returns>
        [HttpGet("GetAll")]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAll();
        }

        /// <summary>
        /// Получить
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>Task<List<Product>><Product></returns>
        [HttpGet("GetAllByUser")]
        public async Task<List<Product>> GetAllByUser(Guid userid)
        {
            return await _productService.GetAllByUser(userid);
        }

        /// <summary>
        /// Получить товар по ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Task<Product?></returns>
        [HttpGet("GetById")]
        public async Task<Product?> GetById(Guid productId)
        {
            var product = await _productService.GetById(productId);
            return product;
        }

        /// <summary>
        /// Создать товар
        /// </summary>
        /// <param name="product_"></param>
        /// <param name="userid"></param>
        /// <returns>Task<Product?></returns>
        [HttpPost("Create")]
        public async Task<Product?> Create(ProductToCreate productDto, Guid userid)
        {
            var product = await _productService.Create(productDto, userid);
            return product;
        }

        /// <summary>
        /// Изменить товар
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        [HttpPut("Edit")]
        public async Task Edit(ProductToCreate product, Guid productID)
        {
            await _productService.Edit(product, productID);
        }


        /// <summary>
        /// Изменить количество товара на складе
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="QuantityInStock"></param>
        /// <returns>Task</returns>
        [HttpPut("")]
        public async Task EditQuantityInStock(Guid productID, uint qantityInStock)
        {
            await _productService.EditQuantityInStock(productID, qantityInStock);
        }

        /// <summary>
        /// Уменьшить количество товара на скаде на 1
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        [HttpPut("ReduceQuantityInStockBy")]
        public async Task ReduceQuantityInStockBy(Guid productID, uint count)
        {
            await _productService.ReduceQuantityInStockBy(productID, count);
        }

        /// <summary>
        /// Удалить товар
        /// </summary>
        /// <param name="productID"></param>
        /// <returns>Task</returns>
        [HttpDelete("Delete")]
        public async Task Delete(Guid productID)
        {
            await _productService.Delete(productID);
        }

        /// <summary>
        /// Удалить все товары пользователя
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>Task</returns>
        [HttpDelete("DeleteAllByUser")]
        public async Task DeleteAllByUser(Guid userid)
        {
            await _productService.DeleteAllByUser(userid);
        }

    }
}
