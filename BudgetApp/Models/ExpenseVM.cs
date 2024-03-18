using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class ExpenseVM
    {
        public int ExpenseId { get; set; }

        public int? BudgetId { get; set; }

        public List<BudgetCategory>? BudgetCategories { get; set; }

        public int? SelectedBudgetCategoryId { get; set; }
        public BudgetCategory? SelectedBudgetCategory { get; set; }

        [Required(ErrorMessage = "There must be an Expense Amount")]
        public int ExpenseAmount { get; set; }

        [StringLength(150)]
        public string ExpenseLocation { get; set; }
    }
}
