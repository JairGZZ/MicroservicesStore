using CatalogService.DTO;
using CatalogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("create")]
        public async Task<ActionResult<CreateProductDto>> CreateProductAsync([FromBody] DTO.CreateProductDto product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return Ok(createdProduct);
        }
        [HttpPost("delete")]

        public async Task<IActionResult> DeleteAsync(int productId)
        {
            await _productService.DeleteAsync(productId);
            return NoContent();
        }
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
    }
}
