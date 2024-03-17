using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface IBudgetRepository
    {
        public Task<Budget> GetBudgetByIdAsync(int id);

        public List<Budget> GetBudgets();

        public Task<int> StoreBudgetsAsync(Budget budget);

        public Task<int> DeleteBudgetAsync(int id);
    }
}
