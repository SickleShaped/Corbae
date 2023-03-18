using AutoMapper;
using Corbae.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Corbae.Controllers
{
    /// <summary>
    /// Контроллер товара
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
    }
}
