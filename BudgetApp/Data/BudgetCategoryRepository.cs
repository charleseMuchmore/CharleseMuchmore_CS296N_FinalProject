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

        public async Task<BudgetCategory> GetBudgetCategoryByIdAsync(int id)
        {
            /*return await dbContext.BudgetCategories.FindAsync(id);*/
          /*  return dbContext.BudgetCategories
                .Include(b => b.Budget)
                .Include(e => e.Category)
                .Include(e => e.Expenses)
                .Where(b => b.BudgetCategoryId == id);*/

            return await dbContext.BudgetCategories
                .Include(c => c.Budget)
                .Include(c => c.Category)
                .Include(c => c.Expenses)
                .Where(c => c.BudgetCategoryId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<int> StoreBudgetCategoriesAsync(BudgetCategory budget)
        {
            await dbContext.BudgetCategories.AddAsync(budget);
            return dbContext.SaveChanges();
        }

        public async Task<int> DeleteBudgetCategoryAsync(int id)
        {
            var bc = await GetBudgetCategoryByIdAsync(id);
            dbContext.BudgetCategories.Remove(bc);
            
            return dbContext.SaveChanges();
        }
    }
}
