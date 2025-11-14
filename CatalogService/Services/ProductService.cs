
using AutoMapper;
using CatalogService.DTO;
using CatalogService.Models;
using CatalogService.Repository;

namespace CatalogService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductDto> CreateProductAsync(CreateProductDto product)
        {

            var productCreate = _mapper.Map<Product>(product);
            var createproduct =  await _productRepository.CreateProductAsync(productCreate);
            await _productRepository.SaveChangesAsync();
            return product; ;
        }

        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<ProductResponse> FindById(int productId)
        {
            var product = await _productRepository.FindById(productId);
            var response = _mapper.Map<ProductResponse>(product);
            return response;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UpdateProduct(int productId, CreateProductDto update)
        {
            throw new NotImplementedException();
        }
    }
}
