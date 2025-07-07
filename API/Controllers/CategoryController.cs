using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Abstraction;
using Shared.DTO.Category;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService cat)
        {
            _categoryService = cat;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetAllCategoryAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryResponseDto?>> GetCategoryByIdAsync(int id)
        {
            return await _categoryService.GetCategoryByIdAsync(id);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CategoryResponseDto?>> GetCategoryByNameAsync(string name)
        {
            return await _categoryService.GetCategoryByNameAsync(name);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCategoryRequestDto createCategoryRequestDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryRequestDto);

            return Created();
        }
    }
}
