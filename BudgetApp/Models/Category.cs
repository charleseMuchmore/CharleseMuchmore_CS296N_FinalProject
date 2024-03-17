using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string? CategoryName { get; set; }
    }
}