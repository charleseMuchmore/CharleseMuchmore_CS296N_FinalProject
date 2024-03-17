using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class BudgetCategory
    {
        public int BudgetCategoryId { get; set; }
        public int BudgetId { get; set; }

        [Required(ErrorMessage = "There must be a Budget")]
        public Budget Budget { get; set; }

        [Required(ErrorMessage = "There must be a Category")]
        public Category? Category { get; set; }

        public int Planned { get; set; }

        public ICollection<Expense> Expenses { get; set; }  = new List<Expense>();

        public int ExpenseTotal { get; set; } = 0;
    }
}
