namespace BudgetApp.Models
{
    public interface IExpensesRepository
    {
        public List<Expense> GetExpenses();
        public Task<Expense> GetExpenseById(int id);
        public Task<int> StoreExpense(Expense expense);
    }
}
