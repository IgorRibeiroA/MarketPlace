using MarketPlace.Application.DTOs;
using MarketPlace.Application.Interfaces;
using MarketPlace.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto)
        {
            var createdProduct = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProductAsync(productDto);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
