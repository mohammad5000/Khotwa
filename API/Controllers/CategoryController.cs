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


        [HttpPost("create")]
        public async Task<ActionResult<CategoryDto>> Create(CategoryDto cat) {

            await _categoryService.CreateCategory(cat);
            return cat;
             
        }
    }
}
