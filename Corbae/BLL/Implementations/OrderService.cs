using Corbae.BLL.Interfaces;

namespace Corbae.BLL.Implementations
{
    public class OrderService:IOrderService
    {
        private readonly ApiDbContext _dbContext;

        public OrderService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
