namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public AppUser AppUser { get; set; }

        public ICollection<Expense> BudgetExpenses { get; set; } = new List<Expense>();

        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();

        public ICollection<Income> BudgetIncomes { get; set; } = new List<Income>();    

    }
}