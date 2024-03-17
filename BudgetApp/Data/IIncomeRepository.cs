using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface IIncomeRepository
    {
        public Task<Income> GetIncomeByIdAsync(int id);

        public List<Income> GetIncomes();

        public Task<int> StoreIncomesAsync(Income income);

        public Task<int> DeleteIncomeAsync(int id);
    }
}
