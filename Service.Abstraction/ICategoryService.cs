using Shared.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface ICategoryService
    {
        public Task CreateCategory(CategoryDto createCategory);
        public void UpdateCategory(int id , CategoryDto updateCategory);
        public void DeleteCategory(int id);
    }
}
