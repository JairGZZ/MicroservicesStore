using CatalogService.Models;

namespace CatalogService.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> FindById(int categoryId);
        Task DeleteAsync(int categoryId);
        Task<Category> UpdateCategory(int categoryId, Category update);
        Task SaveChangesAsync();
        Task<Category> CreateCategoryAsync(Category category);

    }
}
