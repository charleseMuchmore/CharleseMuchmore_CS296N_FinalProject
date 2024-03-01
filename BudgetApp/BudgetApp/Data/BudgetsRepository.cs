using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class BudgetsRepository : IBudgetsRepository
    {
        private AppDbContext dbContext;
        public BudgetsRepository(AppDbContext context)
        {
            dbContext = context;
        }
        public async Task<Budget> GetBudgetById(int id)
        {
            return await dbContext.Budgets.FindAsync(id);
        }

        public Task<List<Budget>> GetBudgets()
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreBudget(Budget expense)
        {
            throw new NotImplementedException();
        }

        List<Budget> IBudgetsRepository.GetBudgets()
        {
            throw new NotImplementedException();
        }
    }
}
