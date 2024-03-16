﻿namespace BudgetApp.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }   

        public string? BudgetName { get; set;}

        public AppUser AppUser { get; set;}

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}

        public ICollection<Expense>? BudgetExpenses { get; set;} 

        public ICollection<BudgetCategory>? BudgetCategories { get; set;}

        public ICollection<Income>? BudgetIncomes { get; set;}
    }
}
