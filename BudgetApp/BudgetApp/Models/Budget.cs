namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public IList<Expense> Expenses { get; set; }

        public IList<Category> Categories { get; set; }

        public IList<Income> Incomes { get; set; }

    }
}
