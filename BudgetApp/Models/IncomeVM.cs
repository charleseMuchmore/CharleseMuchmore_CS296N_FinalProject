namespace BudgetApp.Models
{
    public class IncomeVM
    {
        public int IncomeId { get; set; }

        public int BudgetId { get; set; }

        public int IncomeAmount { get; set; }

        public DateOnly IncomeDate { get; set; }

        public string? IncomeSource { get; set; }
    }
}
