using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class ExpenseController : Controller
    {
        IBudgetRepository budgetRepository;
        IBudgetCategoryRepository budgetCategoryRepository;
        IExpenseRepository expenseRepository;
        UserManager<AppUser> userManager;
        public ExpenseController(UserManager<AppUser> userMngr, IBudgetRepository br, IIncomeRepository ir, IBudgetCategoryRepository bcr, IExpenseRepository er)
        {
            userManager = userMngr;
            budgetRepository = br;
            expenseRepository = er;
            budgetCategoryRepository = bcr;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            //get all expenses for current user
            List<Expense> expenses = expenseRepository.GetExpenses()
                .Where(a => a.AppUser == user)
                .ToList();
            return View(expenses);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Expense(int expenseId)
        {
            var expense = await expenseRepository.GetExpenseByIdAsync(expenseId);
            return View(expense);
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddExpense(int? budgetId = null)
        {
            var model = new ExpenseVM();
            
            if (budgetId != null)
            {
                model.BudgetId = (int)budgetId;
                var bcs = budgetCategoryRepository.GetBudgetCategories().Where(a => a.BudgetId == budgetId).ToList();
                foreach (var c in bcs)
                {
                    model.BudgetCategoryIds.Add(c.BudgetCategoryId);
                }
            }
            else
            {
                model.BudgetId = 0;
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddExpense(ExpenseVM model)
        {
            var expense = new Expense();

            if (model.BudgetId != 0 && model.BudgetId != null)
            {
                expense.BudgetId = model.BudgetId;
                expense.Budget = await budgetRepository.GetBudgetByIdAsync(model.BudgetId);
            }
            else
            {
                expense.BudgetId = null;
            }

            var user = await userManager.GetUserAsync(User);
            expense.AppUser = user;

            //TODO: implement BudgetCategory connection

            var datetime = DateTime.Now;
            expense.ExpenseDate = DateOnly.FromDateTime(datetime);

            expense.ExpenseAmount = model.ExpenseAmount;

            expense.ExpenseLocation = model.ExpenseLocation;

            await expenseRepository.StoreExpensesAsync(expense);

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteExpense(int expenseId)
        {
            var model = new ExpenseVM();
            model.ExpenseId = expenseId;
            var expense = await expenseRepository.GetExpenseByIdAsync(expenseId);
            model.ExpenseLocation = expense.ExpenseLocation;
            model.ExpenseAmount = expense.ExpenseAmount;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteExpense(ExpenseVM model)
        {
            await expenseRepository.DeleteExpenseeAsync(model.ExpenseId);
            return RedirectToAction("Index");
        }


    }
}
