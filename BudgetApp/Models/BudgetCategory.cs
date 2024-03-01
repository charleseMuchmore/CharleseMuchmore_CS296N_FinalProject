using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class BudgetCategory
    {
        public int BudgetCategoryId { get; set; }
        public int BudgetId { get; set; }

        public Budget Budget { get; set; }  

        public Category? Category { get; set; }

        public int Planned { get; set; }

        public int Spent { get; set; }
    }
}
