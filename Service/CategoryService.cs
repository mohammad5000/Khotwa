using Domain.Exceptions;
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

        public async Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var cat = new Category
            {
                Name = createCategoryRequestDto.CategoryName.ToLower(),
            };
            _repository.CreateCategory(cat);
            await _unitWork.SaveAsync();
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoryAsync()
        {
            var categories = await _repository.GetAllCategoryAsync();

            if (categories == null)
                throw new CategoryNotFoundException("Categories not found.");

            var categoryResponseDtos = new List<CategoryResponseDto>();

            foreach (var category in categories)
            {
                categoryResponseDtos.Add(new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }

            return categoryResponseDtos;
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException("Category not found.");

            var categoryResponseDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryResponseDto;
        }

        public async Task<CategoryResponseDto?> GetCategoryByNameAsync(string name)
        {
            var category = await _repository.GetCategoryByNameAsync(name);
            if (category == null)
                throw new CategoryNotFoundException("Category not found.");

            var categoryResponseDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
            return categoryResponseDto;
        }
    }
}
