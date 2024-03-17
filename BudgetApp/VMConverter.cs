using BudgetApp.Models;

namespace BudgetApp
{
    public class VMConverter
    {
        public static BudgetVM ToBudgetVM(Budget b)
        {
            BudgetVM bvm = new BudgetVM();
            bvm.BudgetID = b.BudgetId;
            bvm.BudgetName = b.BudgetName;
            bvm.StartDate = b.StartDate;
            bvm.EndDate = b.EndDate;
            bvm.BudgetExpenses = b.BudgetExpenses;
            bvm.BudgetCategories = b.BudgetCategories;
            bvm.BudgetIncomes = b.BudgetIncomes;
            if (b.BudgetExpenses != null)
            {
                foreach (var e in bvm.BudgetExpenses)
                {
                    bvm.ExpenseTotal += e.ExpenseAmount;
                }
            } else
            {
                bvm.BudgetExpenses = null;
            }
            if (b.BudgetIncomes != null)
            {
                foreach (var e in bvm.BudgetIncomes)
                {
                    bvm.IncomeTotal += e.IncomeAmount;
                }
            } else
            {
                bvm.BudgetIncomes = null;
            }
            return bvm;
        }
    }
}
