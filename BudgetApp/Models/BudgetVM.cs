﻿using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class BudgetVM
    {
        public int BudgetID { get; set; }
        public string? BudgetName { get; set; }

        [Required(ErrorMessage = "There must be a Starting Date")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "There must be an Ending Date")]
        public string EndDate { get; set; }

        public ICollection<Expense> BudgetExpenses { get; set; }

        public ICollection<BudgetCategory> BudgetCategories { get; set; }

        public ICollection<Income> BudgetIncomes { get; set; }

        public int ExpenseTotal { get; set; }

        public int IncomeTotal { get; set;}

        public int PlannedTotal {  get; set; }
    }
}
