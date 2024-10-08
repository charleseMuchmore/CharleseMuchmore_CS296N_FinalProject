﻿using BudgetApp.Models;

namespace BudgetApp.Data
{
    public interface IBudgetCategoryRepository
    {
        public Task<BudgetCategory> GetBudgetCategoryByIdAsync(int id);

        public List<BudgetCategory> GetBudgetCategories();

        public Task<int> StoreBudgetCategoriesAsync(BudgetCategory budget);

        public int UpdateBudgetCategoriesAsync(BudgetCategory budget);

        public Task<int> DeleteBudgetCategoryAsync(int id);
    }
}
