using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    public class SellerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
