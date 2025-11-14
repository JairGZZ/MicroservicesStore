using CatalogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }
        [HttpPost("create")]
        public async Task<ActionResult<DTO.CategoryDTO>> CreateCategoryAsync([FromBody] DTO.CategoryDTO category)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return Ok(createdCategory);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(int categoryId)
        {
            await _categoryService.DeleteAsync(categoryId);
            return NoContent();
        }
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<DTO.CategoryDTO>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }
        [HttpGet("findByid")]
        public async Task<ActionResult<DTO.CategoryDTO>> FindById(int categoryId)
        {
            var category = await _categoryService.FindById(categoryId);
            return Ok(category);
        }
        [HttpPut("update")]
        public async Task<ActionResult<DTO.CategoryDTO>> UpdateCategory(int categoryId, [FromBody] DTO.CategoryDTO update)
        {
            var updatedCategory = await _categoryService.UpdateCategory(categoryId, update);
            return Ok(updatedCategory);
        }
    }
}
