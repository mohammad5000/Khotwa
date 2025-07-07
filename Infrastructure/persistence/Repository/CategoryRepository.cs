using Domain.Interface;
using Domain.Model;
using Infrastructure.persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {   readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateCategory(Category category)
        {
           _context.Categories.Add(category);    
        }
        public void DeleteCategory(int id) => throw new NotImplementedException();
        public Task<IEnumerable<Category>> GetAllCategoryAsync() => throw new NotImplementedException();
        public Task<Category> GetCategoryAsync(int id) => throw new NotImplementedException();
        public void UpdateCategory(Category category) => throw new NotImplementedException();
    }
}
