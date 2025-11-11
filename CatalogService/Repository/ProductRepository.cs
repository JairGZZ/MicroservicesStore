using CatalogService.DataBase;
using CatalogService.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly CatalogDbContext _context;
        public ProductRepository(CatalogDbContext context)
        {
            _context = context;

        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var createProduct = await _context.Products.AddAsync(product);
            return product;
        }

        public async Task DeleteAsync(int productId)
        {
            var product = await FindById(productId);
             _context.Products.Remove(product);
        }

        public async Task<Product> FindById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        
        }

        public async Task<Product> UpdateProduct(int productId, Product update)
        {
            var productToUpdate = await FindById(productId);
            productToUpdate.Id = update.Id;
            productToUpdate.Name = update.Name;
            productToUpdate.Description = update.Description;
            productToUpdate.Price = update.Price;
            productToUpdate.Stock = update.Stock;
            productToUpdate.CategoryId = update.CategoryId;

             _context.Products.Update(productToUpdate);

            return productToUpdate;
        }
    }
}
