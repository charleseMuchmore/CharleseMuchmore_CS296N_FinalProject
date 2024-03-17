namespace BudgetApp.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public int BudgetId { get; set; }

        public AppUser AppUser { get; set; }
        public Budget Budget { get; set; }  

        public int BudgetCategoryId { get; set; }

        public BudgetCategory BudgetCategory { get; set; }

        public DateOnly ExpenseDate { get; set; }
        public int ExpenseAmount { get; set; }

        public string ExpenseLocation { get; set; }
    }
}