using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private AppDbContext dbContext;
        public CategoriesRepository(AppDbContext context)
        {
            dbContext = context;
        }
        public Task<List<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreCategory(Category category)
        {
            throw new NotImplementedException();
        }

        List<Category> ICategoriesRepository.GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
