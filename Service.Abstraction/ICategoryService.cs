using Shared.DTO.Category;

namespace Service.Abstraction
{
    public interface ICategoryService
    {
        public Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        // public Task<CategoryDto> getCategoryById(int id);
        // public void UpdateCategory(int id , CategoryDto updateCategory);
        // public void DeleteCategory(int id);
    }
}
