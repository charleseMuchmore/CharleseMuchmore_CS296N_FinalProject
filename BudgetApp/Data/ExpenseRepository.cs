using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class ExpenseRepository : IExpenseRepository
    {
        public Task<int> DeleteExpenseeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Expense> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreExpensesAsync(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
