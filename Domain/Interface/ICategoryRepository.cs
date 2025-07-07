using Domain.Model;

namespace Domain.Interface
{
    public interface ICategoryRepository
    {
        public Task<Category?> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
        public void CreateCategory(Category category);
    }
}
