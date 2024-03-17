using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BudgetApp.Data
{
    public class IncomeRepository : IIncomeRepository
    {
        private AppDbContext dbContext;
        public IncomeRepository(AppDbContext dc)
        {
            dbContext = dc;
        }

      

        public async Task<Income> GetIncomeByIdAsync(int id)
        {
            /*return await dbContext.Incomes.FindAsync(id);*/
            return dbContext.Incomes
                .Where(i => i.IncomeId == id)
                .Include(i => i.AppUser)
                .Include(i => i.Budget)
                .FirstOrDefault();
        }

        public List<Income> GetIncomes()
        {
            return dbContext.Incomes
                .Include(b => b.AppUser)
                .Include(e => e.Budget)
                .ToList<Income>();
        }

        public async Task<int> StoreIncomesAsync(Income income)
        {
            await dbContext.Incomes.AddAsync(income);
            return dbContext.SaveChanges();
        }

        public async Task<int> DeleteIncomeAsync(int id)
        {
            var b = await GetIncomeByIdAsync(id);

            dbContext.Incomes.Remove(b);

            return dbContext.SaveChanges();
        }
    }
}
