using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Exceptions.OrderExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Exceptions.UserExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.Exceptions.UserExceptions;
using Corbae.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Corbae.BLL.Implementations
{
    /// <summary>
    /// Класс, в котором реализованы методы взаимодействия с заказом
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public OrderService(ApiDbContext dbContext, IMapper mapper, IUserService userService, IProductService productService, ICartService cartService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userService = userService;
            _productService = productService;
            _cartService = cartService;
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
        /// Получить данные из таблицы OrderProducts по ID заказа
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public async Task<List<OrderProduct>> GetOrderProductsByOrderID(Guid orderID)
        {
            return await _dbContext.OrdersProducts.Include(u => u.Product).Where(u => u.OrderID == orderID).ToListAsync();
        }

        /// <summary>
        /// Сделать заказ
        /// </summary>
        /// <returns>Task<Order?></returns>
        public async Task MakeAnOrder(List<Guid> productsID, Guid userID, string deliveryPlace)
        {
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            Order order = new Order();
            order.OrderID = new Guid();
            order.CreationDate = DateTime.UtcNow;
            order.DeliveryPlace = deliveryPlace;
            order.UserID = userID;
            order.Status = "created";

            var user = await _userService.GetById(userID);
            if (user == null) throw new UserNotFoundException();

            var cartProducts = await _cartService.GetCartProductsByUserId(userID);
            foreach (var product in cartProducts)
            {
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.OrderProductID = new Guid();
                orderProduct.ProductID = product.ProductID;
                orderProduct.OrderID = order.OrderID;
                orderProducts.Add(orderProduct);

                if (product.Product == null) throw new NoProductWithThatIdException(product.ProductID);
                order.Price += product.Product.Price;

            }
            if (user.Money < order.Price) throw new NoEnoughMoneyException(user.Money, order.Price);
            await _dbContext.OrdersProducts.AddRangeAsync(orderProducts);
            var deleted= await _dbContext.CartProducts.Where(u => u.UserID == userID).ExecuteDeleteAsync();
            var orderDB= _mapper.Map<OrderDB>(order);
            await _dbContext.Orders.AddAsync(orderDB);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Оплатить заказ
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task PayForTheOrder(Guid orderID, Guid userID)
        {
            List<Product> products = new List<Product>();
            var order = await GetOrderById(orderID);
            if (order == null) throw new OrderNotFoundException();
            var user = await _userService.GetById(userID);
            if (user == null) throw new UserNotFoundException();

            var orderProducts = await _dbContext.OrdersProducts.Include(u => u.Product).Include(u => u.Product.User).Where(u => u.OrderID == orderID).ToListAsync();

            if (user.Money < order.Price) throw new NoEnoughMoneyException(user.Money, order.Price);
            foreach (var orderProduct in orderProducts)
            {
                if (orderProduct.Product.QuantityInStock < 1) throw new ProductOutOfStockException(orderProduct.Product.Name);
            }
            foreach (var orderProduct in orderProducts)
            {
                orderProduct.Product.User.Money += orderProduct.Product.Price;
                orderProduct.Product.QuantityInStock--;
            }

            user.Money -= order.Price;
            order.Status = "paid";

            await _dbContext.SaveChangesAsync();



        }
    }
}

