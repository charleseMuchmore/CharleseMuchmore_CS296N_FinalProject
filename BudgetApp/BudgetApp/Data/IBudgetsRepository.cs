namespace BudgetApp.Models
{
    public interface IBudgetsRepository
    {
        public List<Budget> GetBudgets();
        public Task<Budget> GetBudgetById(int id);
        public Task<int> StoreBudget(Budget expense);
    }
}
