using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "There must be an Expense Amount")]
        public int ExpenseAmount { get; set; }

        [StringLength(150)]
        public string ExpenseLocation { get; set; }
    }
}