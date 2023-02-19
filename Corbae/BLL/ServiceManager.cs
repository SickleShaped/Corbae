using Corbae.BLL.Interfaces;

namespace Corbae.BLL
{
    public class ServiceManager
    {
        private ICartService _cartService;
        private IOrderService _orderService;
        private IProductService _productService;
        private IUserService _userService;

        public ServiceManager(ICartService cartService, IOrderService orderService, IProductService productService, IUserService userService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
        }

        public ICartService CartService { get {return _cartService; } }
        public IOrderService OrderService { get { return _orderService; } }
        public IProductService ProductService { get { return _productService; } }
        public IUserService UserService { get { return _userService; } }
    }
}
