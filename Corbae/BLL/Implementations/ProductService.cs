using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DTO;
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
        /// Получить всех пользователей
        /// </summary>
        /// <returns>List<User></USER></returns>
        public async Task<List<Product>> GetAll()
        {
            var UsersDB = await _dbContext.Products.Include(u => u.Orders).AsNoTracking().ProjectTo<Product>(_mapper.ConfigurationProvider).ToListAsync();
            return UsersDB;
        }
    }
}
