using Domain.Model;

namespace Domain.Interface
{
    public interface ICategoryRepository
    {
        public Task<Category> GetCategoryAsync(int id);
        public Task<IEnumerable<Category>> GetAllCategoryAsync();
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int id);
    }
}
