using CatalogService.DTO;

namespace CatalogService.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> FindById(int categoryId);
        Task DeleteAsync(int categoryId);
        Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO update);
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO category);
    }
}
