using Domain.Interface;
using Domain.Model;
using Infrastructure.persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
