using Corbae.BLL.Interfaces;
using Corbae.DAL;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с заказом
    /// </summary>
    public class OrderService:IOrderService
    {
        private readonly ApiDbContext _dbContext;

        public OrderService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
