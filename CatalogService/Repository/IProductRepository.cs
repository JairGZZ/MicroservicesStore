
using CatalogService.Models;

namespace CatalogService.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> FindById(int productId);
        Task DeleteAsync(int productId);
        Task<Product> UpdateProduct(int productId, Product update);
        Task SaveChangesAsync();
        Task<Product> CreateProductAsync(Product product);
    }
}
