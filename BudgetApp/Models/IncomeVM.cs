using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class IncomeVM
    {
        public int IncomeId { get; set; }

        public int? BudgetId { get; set; }

        [Required(ErrorMessage = "There must be an Income Amount")]
        public int IncomeAmount { get; set; }

        public DateOnly IncomeDate { get; set; }

        [StringLength(150)]
        public string? IncomeSource { get; set; }
    }
}
