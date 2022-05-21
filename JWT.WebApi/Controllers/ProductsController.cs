using AutoMapper;
using JWT.Business.Interfaces;
using JWT.Entities.Concrete;
using JWT.Entities.Dtos.ProductDtos;
using JWT.WebApi.CustomFilters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace JWT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            //if (product == null) return NotFound();
            return Ok(product);
        }
        [ValidModel] //no need to write modelstate inside method
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto product)
        {
            await _productService.Add(_mapper.Map<Product>(product));
            return Created("", product);
        }
        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            await _productService.Update(_mapper.Map<Product>(product));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productService.Delete(product);
            return NoContent();
        }
        [HttpGet]
        [Route("/error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            return Problem(detail: "One or more error occurred, will be fixed soon", errorInfo?.Error.Message);
        }
    }
}
