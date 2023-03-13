using Corbae.BLL.Interfaces;

namespace Corbae.BLL
{
    public class ServiceManager
    {
        private ICartService _cartService;
        private IOrderService _orderService;
        private IProductService _productService;
        private IUserService _userService;
        private IAuthService _authService;

        public ServiceManager(ICartService cartService, IOrderService orderService, IProductService productService, IUserService userService, IAuthService authService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
            _authService = authService;
        }

        public ICartService CartService { get {return _cartService; } }
        public IOrderService OrderService { get { return _orderService; } }
        public IProductService ProductService { get { return _productService; } }
        public IUserService UserService { get { return _userService; } }
        public IAuthService AuthService { get { return _authService; } }
    }
}
