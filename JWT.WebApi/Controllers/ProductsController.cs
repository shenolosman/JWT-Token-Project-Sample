using JWT.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JWT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            _productService.GetAll();
            return Ok();
        }
    }
}
