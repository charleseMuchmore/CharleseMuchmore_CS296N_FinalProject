using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface IExpenseRepository
    {
        public Task<Expense> GetExpenseByIdAsync(int id);

        public List<Expense> GetExpenses();

        public Task<int> StoreExpensesAsync(Expense expense);

        public Task<int> DeleteExpenseeAsync(int id);
    }
}
