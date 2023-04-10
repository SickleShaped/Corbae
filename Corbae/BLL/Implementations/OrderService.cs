using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.OrderExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Exceptions.UserExceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с заказом
    /// </summary>
    public class OrderService:IOrderService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        public OrderService(ApiDbContext dbContext, IMapper mapper, IUserService userService, IProductService productService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
            _productService = productService;
        }

        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns>List<Order></returns>
        public async Task<List<Order>> GetAll()
        {
            var orders = await _dbContext.Orders.AsNoTracking().ProjectTo<Order>(_mapper.ConfigurationProvider).ToListAsync();
            return orders;
        }

        /// <summary>
        /// Получить заказы по id пользователя
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <returns>List<Order></returns>
        public async Task<List<Order>> GetOrdersByCustomerId(Guid userId)
        {
            var orders = await _dbContext.Orders.Where(p => p.UserID == userId).AsNoTracking().ProjectTo<Order>(_mapper.ConfigurationProvider).ToListAsync();
            return orders;
        }

        /// <summary>
        /// Получить заказы по дате
        /// </summary>
        /// <param name="date">Дата заказа</param>
        /// <returns>List<Order><Order></returns>
        public async Task<List<Order>> GetOrdersByDate(DateTime date)
        {
            var orders = await _dbContext.Orders.Where(p => p.CreationDate == date).AsNoTracking().ProjectTo<Order>(_mapper.ConfigurationProvider).ToListAsync();
            return orders;
        }

        /// <summary>
        /// Получить заказ по ID
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public async Task<Order?> GetOrderById(Guid orderID)
        {
            return await _dbContext.Orders.ProjectTo<Order>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(u => u.OrderID == orderID);
        }

        /// <summary>
        /// Сделать заказ
        /// </summary>
        /// <returns>Order?</returns>
        public async Task<Order?> MakeAnOrder(List<Guid> productsID, Guid userID)
        {
            List<Product> products = new List<Product>();
            User user = await _userService.GetById(userID);
            if(user == null)
            {
                throw new NoUserWithThatIdException(userID);
            }

            decimal price = 0;

            foreach(var productID in productsID)
            {
                var product = await _productService.GetById(productID);
                if(product != null)
                {
                    products.Add(product);
                    price += product.Price;
                }
                
            }

            if(user.Money < price)
            {
                throw new NoEnoughMoneyException(user.Money, price);
            }
            



            //заглушка
            var p = new Order();
            return  p;
        }
    }
}
