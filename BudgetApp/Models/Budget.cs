namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public AppUser AppUser { get; set; }

        public IList<Expense> BudgetExpenses { get; set; }

        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();

        public IList<Income> BudgetIncomes { get; set; }

    }
}