﻿namespace BudgetApp.Models
{
    public class Income
    {
        public int IncomeId { get; set; }

        public int? BudgetId { get; set; }

        public AppUser AppUser { get; set; }
        public Budget? Budget { get; set; }

        public int IncomeAmount { get; set; }

        public DateOnly IncomeDate { get; set; }

        public string? IncomeSource { get; set; }
    }
}