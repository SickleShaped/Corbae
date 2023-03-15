using Corbae.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUserService _userService;

        public ProductController(IUserService userService)
        {
            _userService = _userService;
        }
    }
}
