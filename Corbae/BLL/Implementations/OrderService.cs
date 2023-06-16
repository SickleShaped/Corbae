using AutoMapper;
using AutoMapper.QueryableExtensions;
using Corbae.BLL.Enums;
using Corbae.BLL.Exceptions.OrderExceptions;
using Corbae.BLL.Exceptions.ProductExceptions;
using Corbae.BLL.Exceptions.UserExceptions;
using Corbae.BLL.Interfaces;
using Corbae.DAL;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DBModels.Intermediate_Models;
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
        public async Task<List<OrderProductReturn>> GetOrderProductsByOrderID(Guid orderID)
        {
            var products = await _dbContext.OrderProducts.Where(u => u.OrderID == orderID).Include(u => u.Product).ToListAsync();

            List<OrderProductReturn> orderproducts = new List<OrderProductReturn>();

            foreach (var orderproduct in products)
            {
                OrderProductReturn product2 = new OrderProductReturn();
                product2.ProductID = orderproduct.Product.ProductID;
                product2.Name = orderproduct.Product.Name;
                product2.Description = orderproduct.Product.Description;
                product2.Price = orderproduct.Product.Price;
                product2.QuantityInStock = orderproduct.Product.QuantityInStock;
                product2.Category = orderproduct.Product.Category;
                product2.UserID = orderproduct.Product.UserID;
                product2.OrderProductID = orderproduct.OrderProductID;

                orderproducts.Add(product2);
            }

            return orderproducts;

        }

        /// <summary>
        /// Сделать заказ
        /// </summary>
        /// <returns>Task<Order?></returns>
        public async Task MakeAnOrder(Guid userID, string deliveryPlace)
        {
            var cartproducts = await _dbContext.CartProducts.Where(u => u.UserID == userID)
                                                            .Include(u => u.Product)
                                                                .ThenInclude(u=>u.User)
                                                            .ToListAsync();

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == userID);

            List<OrderProduct> orderProducts = new List<OrderProduct>();
            OrderDB order = new OrderDB();
            order.OrderID = Guid.NewGuid();
            order.UserID = userID;
            order.DeliveryPlace = deliveryPlace;
            order.CreationDate = DateTime.UtcNow;

            decimal orderprice = 0;
            foreach(var cartproduct in cartproducts)
            {
                orderprice += cartproduct.Product.Price;
                if(cartproduct.Product.QuantityInStock>0)
                {
                    cartproduct.Product.QuantityInStock--;
                }
                else
                {
                    throw new NoEnoughProductsException(cartproduct.Product.Name);
                }
            }
            order.Price = orderprice;
            if (user.Money < order.Price) { throw new NoEnoughMoneyException(user.Money, order.Price); }

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            foreach (var cartproduct in cartproducts)
            {
                user.Money -= cartproduct.Product.Price;
                cartproduct.Product.User.Money += cartproduct.Product.Price;
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.OrderProductID = Guid.NewGuid();
                orderProduct.ProductID = cartproduct.Product.ProductID;
                orderProduct.OrderID = order.OrderID;
                orderProducts.Add(orderProduct);
                //await _dbContext.OrderProducts.AddAsync(orderProduct);
            }

            //await _dbContext.OrderProducts.AddRangeAsync(orderProducts);
            await _dbContext.OrderProducts.AddRangeAsync(orderProducts);
            await _dbContext.CartProducts.Where(u => u.UserID == userID).ExecuteDeleteAsync();
            await _dbContext.SaveChangesAsync();
            

            /*
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            Order order = new Order();
            order.OrderID = new Guid();
            order.CreationDate = DateTime.UtcNow;
            order.DeliveryPlace = deliveryPlace;
            order.UserID = userID;
            order.Status = OrderStatusEnum.Status.Created;

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

                if (product == null) throw new NoProductWithThatIdException(product.ProductID);
                order.Price += product.Price;

            }
            if (user.Money < order.Price) throw new NoEnoughMoneyException(user.Money, order.Price);
            await _dbContext.OrderProducts.AddRangeAsync(orderProducts);
            var deleted= await _dbContext.CartProducts.Where(u => u.UserID == userID).ExecuteDeleteAsync();
            var orderDB= _mapper.Map<OrderDB>(order);
            await _dbContext.Orders.AddAsync(orderDB);
            await _dbContext.SaveChangesAsync();*/
        }

    }
}

