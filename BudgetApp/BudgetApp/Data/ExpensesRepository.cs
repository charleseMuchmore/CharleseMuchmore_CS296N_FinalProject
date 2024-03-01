using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class ExpensesRepository : IExpensesRepository
    {
        private AppDbContext dbContext;
        public ExpensesRepository(AppDbContext context)
        {
            dbContext = context;
        }
        public Task<Expense> GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Expense>> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreExpense(Expense expense)
        {
            throw new NotImplementedException();
        }

        List<Expense> IExpensesRepository.GetExpenses()
        {
            throw new NotImplementedException();
        }
    }
}
