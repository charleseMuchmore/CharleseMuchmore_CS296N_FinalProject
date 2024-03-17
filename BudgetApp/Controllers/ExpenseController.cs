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
        IExpenseRepository expenseRepository;
        UserManager<AppUser> userManager;
        public ExpenseController(UserManager<AppUser> userMngr, IBudgetRepository br, IIncomeRepository ir, IBudgetCategoryRepository bcr, IExpenseRepository er)
        {
            userManager = userMngr;
            budgetRepository = br;
            expenseRepository = er;
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
        public IActionResult Expense()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddExpense()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteExpense()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteExpense(int expenseId)
        {
            return View();
        }


    }
}
