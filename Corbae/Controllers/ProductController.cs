using Corbae.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    public class ProductController : Controller
    {
        private readonly ServiceManager _serviceManager;

        public ProductController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
