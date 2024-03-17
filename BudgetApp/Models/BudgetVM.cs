namespace BudgetApp.Models
{
    public class BudgetVM
    {
        public int BudgetID { get; set; }
        public string? BudgetName { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public ICollection<Expense> BudgetExpenses { get; set; }

        public ICollection<BudgetCategory> BudgetCategories { get; set; }

        public ICollection<Income> BudgetIncomes { get; set; }

        public int ExpenseTotal { get; set; }

        public int IncomeTotal { get; set;}
    }
}
