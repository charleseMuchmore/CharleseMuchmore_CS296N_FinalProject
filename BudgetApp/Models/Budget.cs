using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        [StringLength(50)]
        public string? BudgetName { get; set;}

        public AppUser AppUser { get; set;}

        [Required(ErrorMessage = "There must be a Starting Date")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "There must be an Ending Date")]
        public DateOnly EndDate { get; set;}

        public ICollection<Expense>? BudgetExpenses { get; set;} 

        public ICollection<BudgetCategory>? BudgetCategories { get; set;}

        public ICollection<Income>? BudgetIncomes { get; set;}
    }
}
