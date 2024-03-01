namespace BudgetApp.Models
{
    public class Income
    {
        public int IncomeId { get; set; }

        public int BudgetId { get; set; }

        public Budget Budget { get; set; }

        public int IncomeAmount { get; set; }
    }
}