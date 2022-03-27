using MarketApp.DataTransferObject;
using MarketApp.Models;
using MarketApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService? _productService;
        public ProductController(IProductService service)
        {
            this._productService = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts().ToListAsync();
            return Ok(products);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product product;
            try
            {
                product = await _productService.GetById(id);
            }
            catch (NullReferenceException ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            Product newProduct=await _productService.AddProduct(productDto);
            return Ok(newProduct);
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateProduct(int id,ProductDto productDto)
        {
            bool isUpdated = await _productService.UpdateProduct(id, productDto);
            if (!isUpdated)
            {
                return NotFound(id);
            }
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            try
            {
                await _productService.RemoveProduct(id);
            }
            catch (NullReferenceException ex)
            {

                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
