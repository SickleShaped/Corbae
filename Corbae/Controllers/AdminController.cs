using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
