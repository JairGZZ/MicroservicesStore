using AutoMapper;
using CatalogService.DTO;
using CatalogService.Repository;

namespace CatalogService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Repository.ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> FindById(int categoryId)
        {
            var category = await _categoryRepository.FindById(categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> UpdateCategory(int categoryId, CategoryDTO update)
        {
            var categoryUpdate = _mapper.Map<Models.Category>(update);
            var updatedCategory = await _categoryRepository.UpdateCategory(categoryId, categoryUpdate);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }
        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO category)
        {
            var categoryCreate = _mapper.Map<Models.Category>(category);
            var createdCategory = await _categoryRepository.CreateCategoryAsync(categoryCreate);
            return _mapper.Map<CategoryDTO>(createdCategory);
        }
    }
}
