using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private AppDbContext dbContext;
        IBudgetCategoryRepository bcRepository;
        UserManager<AppUser> userManager;
        public BudgetRepository(AppDbContext dc, UserManager<AppUser> userMngr, IBudgetCategoryRepository bcr)
        {
            userManager = userMngr;
            dbContext = dc;
            bcRepository = bcr;
        }
        public async Task<Budget> GetBudgetByIdAsync(int id)
        {
            return dbContext.Budgets
                .Where(b => b.BudgetId == id)
                .Include(b => b.AppUser)
                .Include(e => e.BudgetExpenses)
                .Include(e => e.BudgetCategories)
                .ThenInclude(e => e.Category)
                .Include(e => e.BudgetIncomes)
                .FirstOrDefault();
        }

        public List<Budget> GetBudgets()
        {
            return dbContext.Budgets
                .Include(b => b.AppUser)
                .Include(e => e.BudgetExpenses)
                .Include(e => e.BudgetCategories)
                .Include(e => e.BudgetIncomes)
                .ToList<Budget>();
        }

        public async Task<int> StoreBudgetsAsync(Budget budget)
        {
            await dbContext.Budgets.AddAsync(budget);
            return dbContext.SaveChanges();
        }

        public async Task<int> DeleteBudgetAsync(int id)
        {
            var b = await GetBudgetByIdAsync(id);
            foreach (var c in b.BudgetCategories)
            {
                await bcRepository.DeleteBudgetCategoryAsync(c.BudgetCategoryId);
            }
            dbContext.Budgets.Remove(b);

            return dbContext.SaveChanges();
        }
    }
}
