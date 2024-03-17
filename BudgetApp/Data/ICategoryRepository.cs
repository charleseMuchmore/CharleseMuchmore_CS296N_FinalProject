using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface ICategoryRepository
    {
        public Task<Category> GetCategoryByIdAsync(int id);

        public List<Category> GetCategories();

        public Task<int> StoreCategoriesAsync(Category category);
    }
}
