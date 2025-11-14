using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBase.CatalogDbContext _context;
        public CategoryRepository(DataBase.CatalogDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task DeleteAsync(int categoryId)
        {
            var category = await FindById(categoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> FindById(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId) 
                   ?? throw new KeyNotFoundException("Category not found");
        }
        public async Task<Category> UpdateCategory(int categoryId, Category update)
        {
            var category = await FindById(categoryId);
            category.Name = update.Name;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
