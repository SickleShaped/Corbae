using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
