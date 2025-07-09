using AutoMapper;
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
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IUnitWork unitOfWork, IMapper mapper)
        {
            _repository = repo;
            _unitWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var category = await _repository.GetCategoryByNameAsync(createCategoryRequestDto.CategoryName.ToLower());
            if (category != null)
                throw new CategoryBadRequestException("Category already exists.");
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

            var categoryResponseDtos = _mapper.Map<IEnumerable<CategoryResponseDto>>(categories).ToList();

            return categoryResponseDtos;
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetCategoryByIdAsync(id);
            if (category == null)
                throw new CategoryNotFoundException("Category not found.");

            var categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);
            return categoryResponseDto;
        }

        public async Task<CategoryResponseDto?> GetCategoryByNameAsync(string name)
        {
            var category = await _repository.GetCategoryByNameAsync(name);
            if (category == null)
                throw new CategoryNotFoundException("Category not found.");

            var categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);
            return categoryResponseDto;
        }

        public async Task<bool> CheckCategoryExistsAsync(int id)
        {
            return await _repository.CheckCategoryExistsAsync(id);
        }
        public async Task<bool> CheckCategoryExistsAsync(string name)
        {
            return await _repository.CheckCategoryExistsAsync(name);
        }
    }
}
