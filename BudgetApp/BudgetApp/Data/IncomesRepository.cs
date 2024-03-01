using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class IncomesRepository : IIncomesRepository
    {
        private AppDbContext dbContext;
        public IncomesRepository(AppDbContext context)
        {
            dbContext = context;
        }
        public Task<Income> GetIncomeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetIncomes()
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreIncome(Income income)
        {
            throw new NotImplementedException();
        }

        List<Income> IIncomesRepository.GetIncomes()
        {
            throw new NotImplementedException();
        }
    }
}
