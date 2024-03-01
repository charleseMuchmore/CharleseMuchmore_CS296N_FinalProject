namespace BudgetApp.Models
{
    public interface IIncomesRepository
    {
        public List<Income> GetIncomes();
        public Task<Income> GetIncomeById(int id);
        public Task<int> StoreIncome(Income income);
    }
}
