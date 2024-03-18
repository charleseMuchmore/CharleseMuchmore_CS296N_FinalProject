using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        private AppDbContext dbContext;
        UserManager<AppUser> userManager;
        public ExpenseRepository(AppDbContext dc, UserManager<AppUser> userMngr)
        {
            userManager = userMngr;
            dbContext = dc;
        }
        public Task<int> DeleteExpenseeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseByIdAsync(int id)
        {
            return dbContext.Expenses
                .Where(e => e.ExpenseId == id)
                .Include(a => a.AppUser)
                .Include(a => a.Budget)
                .Include(a => a.BudgetCategory)
                .FirstOrDefaultAsync();
        }

        public List<Expense> GetExpenses()
        {
            return dbContext.Expenses.ToList<Expense>();
        }

        public async Task<int> StoreExpensesAsync(Expense expense)
        {
            await dbContext.Expenses.AddAsync(expense);
            return dbContext.SaveChanges();
        }
    }
}
