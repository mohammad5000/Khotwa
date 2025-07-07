using Domain.Exceptions;
using Domain.Interface;
using Domain.Model;
using Service.Abstraction;
using Shared.DTO.Category;


namespace Service
{
    public class CategoryService : ICategoryService
    {   private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repo)
        {
            _repository = repo;
        }
        public async Task CreateCategory(CategoryDto createCategory)
        {

            if (createCategory.Name == null)
            {
                throw new CategoryNotFoundException("Cat not found");
            }
            
            Category cat = new Category
            {
                Name = createCategory.Name,
            };

            _repository.CreateCategory(cat);
           await _repository.SaveAsync();

            


        }
        
        public void DeleteCategory(int id) => throw new NotImplementedException();

        public async Task<CategoryDto> getCategoryById(int id) {

            var cat = await _repository.GetCategoryAsync(id);
            if (cat == null)
            {
                throw new CategoryNotFoundException($"Cat id: {id} not found");
            }
            var catdto = new CategoryDto
            {
                Name = cat.Name
            };

            return catdto;
        }
        public void UpdateCategory(int id, CategoryDto updateCategory) => throw new NotImplementedException();
    }
}
