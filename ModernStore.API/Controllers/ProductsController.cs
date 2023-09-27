using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;

namespace ModernStore.API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("products")]
        public IActionResult Get()
        {
            var products = _productRepository.Get();
            
            return Ok(products);
        }

    }
}
