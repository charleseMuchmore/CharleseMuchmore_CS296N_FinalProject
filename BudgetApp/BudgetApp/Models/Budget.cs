namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public List<Expense> Expenses { get; set; }

        public List<Category> Categories { get; set; }

        public List<Income> Incomes { get; set; }

    }
}
