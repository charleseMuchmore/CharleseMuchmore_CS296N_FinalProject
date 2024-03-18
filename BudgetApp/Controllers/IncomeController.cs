using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class IncomeController : Controller
    {
        IBudgetRepository budgetRepository;
        IIncomeRepository incomeRepository;
        IBudgetCategoryRepository bcRepository;
        UserManager<AppUser> userManager;
        public IncomeController(UserManager<AppUser> userMngr, IBudgetRepository br, IIncomeRepository ir, IBudgetCategoryRepository bcr)
        {
            userManager = userMngr;
            budgetRepository = br;
            incomeRepository = ir;
            bcRepository = bcr;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            //get all incomes for current user
            List<Income> incomes = incomeRepository.GetIncomes()
                .Where(a => a.AppUser == user)
                .ToList();
            return View(incomes);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Income(int incomeId)
        {
            var income = await incomeRepository.GetIncomeByIdAsync(incomeId);
            return View(income);
        }
        [HttpGet]
        [Authorize]
        public IActionResult AddIncome(int? budgetId = null)
        {
            var model = new IncomeVM();

            if (budgetId != null)
            {
                model.BudgetId = (int)budgetId;
            } else
            {
                model.BudgetId = null;
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddIncome(IncomeVM model)
        {
            Income income = new Income();
            DateTime now = DateTime.Now;
            DateOnly today = DateOnly.FromDateTime(now);
            income.IncomeDate = today;
            income.IncomeAmount = model.IncomeAmount;
            income.IncomeSource = model.IncomeSource;

            var user = await userManager.GetUserAsync(User);
            income.AppUser = user;

            if (model.BudgetId != 0 || model.BudgetId != null)
            {
                income.BudgetId = model.BudgetId;
                var b = await budgetRepository.GetBudgetByIdAsync((int)model.BudgetId);
                income.Budget = b;
            } else
            {
                income.BudgetId = null;
                income.Budget = null;
            }

            await incomeRepository.StoreIncomesAsync(income);

            if (model.BudgetId == 0 || model.BudgetId == null)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Budget", "Budget", new { budgetId = income.BudgetId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteIncome(int incomeId) 
        {
            var model = new IncomeVM();
            model.IncomeId = incomeId;
            var income = await incomeRepository.GetIncomeByIdAsync(incomeId);
            model.IncomeSource = income.IncomeSource;
            model.IncomeAmount = income.IncomeAmount;

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteIncome(IncomeVM model)
        {
            await incomeRepository.DeleteIncomeAsync(model.IncomeId);
            return RedirectToAction("Index");
        }
    }
}
