namespace BudgetApp.Models
{
    public interface ICategoriesRepository
    {
        public List<Category> GetCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<int> StoreCategory(Category category);
    }
}
