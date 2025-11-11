using CatalogService.DTO;
using CatalogService.Models;
using CatalogService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();

            return Ok(products);
        }
        [HttpGet("findByid")]
        public async Task<ActionResult<Product>> FindById(int productId)
        {
            return Ok(await _productRepository.FindById(productId));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
            await _productRepository.SaveChangesAsync();
            return NoContent();


        }
        [HttpPut("update")]
        public async Task<ActionResult<Product>> UpdateProduct(int productId, Product update)
        {
            var updatedProduct = await _productRepository.UpdateProduct(productId, update);
            await _productRepository.SaveChangesAsync();
            return Ok(updatedProduct);
        }
        [HttpPost("create")]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };

            var createdProduct = await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(FindById), new { productId = createdProduct.Id }, createdProduct);
        }


    }
}
