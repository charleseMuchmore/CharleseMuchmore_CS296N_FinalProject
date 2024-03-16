using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class BudgetCategoryRepository : IBudgetCategoryRepository
    {
        private AppDbContext dbContext;
        UserManager<AppUser> userManager;
        public BudgetCategoryRepository(AppDbContext dc, UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
            dbContext = dc;
        }
        public List<BudgetCategory> GetBudgetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<BudgetCategory> GetBudgetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> StoreBudgetCategoriesAsync(BudgetCategory budget)
        {
            await dbContext.BudgetCategories.AddAsync(budget);
            return dbContext.SaveChanges();
        }
    }
}
