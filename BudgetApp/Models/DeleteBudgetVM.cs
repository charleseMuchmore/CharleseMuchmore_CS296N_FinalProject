namespace BudgetApp.Models
{
    public class DeleteBudgetVM
    {
        public int BudgetId { get; set; }

        public string BudgetName { get; set; }
        public ICollection<BudgetCategory>? BudgetCategories { get; set; }
    }
}
