using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext dbContext;
        UserManager<AppUser> userManager;
        public CategoryRepository(AppDbContext dc, UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
            dbContext = dc;
        }

        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList<Category>();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

        public Task<int> StoreCategoriesAsync(Category category)
        {
            throw new NotImplementedException();
        }
       
    }
}
