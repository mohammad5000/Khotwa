using Shared.DTO.Category;

namespace Service.Abstraction
{
    public interface ICategoryService
    {
        public Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryDto);
        public Task<IEnumerable<CategoryResponseDto>> GetAllCategoryAsync();
        public Task<CategoryResponseDto?> GetCategoryByIdAsync(int id);
        public Task<CategoryResponseDto?> GetCategoryByNameAsync(string name);
    }
}
