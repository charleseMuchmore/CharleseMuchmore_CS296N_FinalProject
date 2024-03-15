using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class BudgetRepository : IBudgetRepository
    {
        private AppDbContext dbContext;

        public BudgetRepository(AppDbContext dc)
        {
            dbContext = dc;
        }
        public async Task<Budget> GetBudgetByIdAsync(int id)
        {
            return await dbContext.Budgets.FindAsync(id);
        }

        public List<Budget> GetBudgets()
        {
            return dbContext.Budgets
                .Include(b => b.AppUser)
                .ToList();
        }

        public async Task<int> StoreBudgetsAsync(Budget budget)
        {
            await dbContext.Budgets.AddAsync(budget);
            return dbContext.SaveChanges();
        }
    }
}
