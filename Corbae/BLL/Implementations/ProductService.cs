using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.Models;

namespace Corbae.BLL.Implementations
{
    public class ProductService:IProductService
    {
        private readonly ApiDbContext _dbContext;

        public ProductService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
