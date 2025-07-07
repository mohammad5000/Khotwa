using Domain.Interface;
using Domain.Model;
using Service.Abstraction;
using Shared.DTO.Category;


namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitWork _unitWork;
        public CategoryService(ICategoryRepository repo, IUnitWork unitOfWork)
        {
            _repository = repo;
            _unitWork = unitOfWork;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var cat = new Category
            {
                Name = createCategoryDto.CategoryName
            };
            _repository.CreateCategory(cat);
            await _unitWork.SaveAsync();
        }

        // public async Task<CategoryDto> getCategoryById(int id)
        // {

        //     var cat = await _repository.GetCategoryAsync(id);
        //     if (cat == null)
        //     {
        //         throw new CategoryNotFoundException($"Cat id: {id} not found");
        //     }
        //     var catdto = new CategoryDto
        //     {
        //         Name = cat.Name
        //     };

        //     return catdto;
        // }

        // public void DeleteCategory(int id) => throw new NotImplementedException();

        // public void UpdateCategory(int id, CategoryDto updateCategory) => throw new NotImplementedException();
    }
}
