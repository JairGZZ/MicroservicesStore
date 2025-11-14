using CatalogService.DTO;

namespace CatalogService.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProducts();
        Task<ProductResponse> FindById(int productId);
        Task DeleteAsync(int productId);
        Task<ProductResponse> UpdateProduct(int productId, CreateProductDto update);
        Task SaveChangesAsync();
        Task<CreateProductDto> CreateProductAsync(CreateProductDto product);
    }
}
