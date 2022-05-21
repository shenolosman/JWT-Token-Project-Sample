﻿using JWT.Business.Interfaces;
using JWT.Entities.Concrete;
using JWT.Entities.Dtos.ProductDtos;
using JWT.WebApi.CustomFilters;
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
            await _productService.Add(new Product { Name = product.Name });
            return Created("", product);
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidId<Product>))]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productService.Delete(product);
            return NoContent();
        }
    }
}
