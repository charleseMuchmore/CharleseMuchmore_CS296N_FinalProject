using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BudgetApp.Controllers
{
    public class BudgetController : Controller
    {
        IBudgetRepository budgetRepository;
        ICategoryRepository categoryRepository;
        IBudgetCategoryRepository bcRepository;
        UserManager<AppUser> userManager;
        public BudgetController(UserManager<AppUser> userMngr, IBudgetRepository br, ICategoryRepository cr, IBudgetCategoryRepository bcr)
        {
            userManager = userMngr;
            budgetRepository = br;
            categoryRepository = cr;
            bcRepository = bcr;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            List<Budget> budgets = budgetRepository.GetBudgets()
                .Where(u => u.AppUser.Id == user.Id)
                .ToList<Budget>();
            List<BudgetVM> models = new List<BudgetVM>();
            foreach ( var b in budgets )
            {
                var bvm = VMConverter.ToBudgetVM(b);
                models.Add( bvm );
            }
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Budget(int budgetId)
        {
                BudgetVM model = new BudgetVM();
                Budget b = await budgetRepository.GetBudgetByIdAsync(budgetId);
                model = VMConverter.ToBudgetVM(b);
                foreach (var bcat in model.BudgetCategories)
                {
                    foreach (var e in bcat.Expenses)
                    {
                        bcat.ExpenseTotal += e.ExpenseAmount;
                    }
                }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddCategory(int budgetId)
        {
            List<Category> cats = categoryRepository.GetCategories();
            BudgetCategoryVM model = new BudgetCategoryVM();
            model.Categories = cats;
            model.BudgetId = budgetId;
            return View(model);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddCategory(Category model, int PlannedAmount, int budgetId)
        {
            BudgetCategory budgetCat = new BudgetCategory();
            budgetCat.BudgetId = budgetId;
            var b = await budgetRepository.GetBudgetByIdAsync(budgetId);
            budgetCat.Budget = b;

            List<Category> bcats = categoryRepository.GetCategories()
                .Where(c => c.CategoryName == model.CategoryName)
                .ToList();
            budgetCat.Category = bcats[0]; //note: categories are unique, and the list should only have 1 category 
            budgetCat.Planned = PlannedAmount;
            budgetCat.Expenses = new List<Expense>();
            budgetCat.ExpenseTotal = 0;

            await bcRepository.StoreBudgetCategoriesAsync(budgetCat);

            return RedirectToAction("Budget", new { budgetId = budgetId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteBudgetCategory(int bcatId, int budgetId)
        {
            var bcat = await bcRepository.GetBudgetCategoryByIdAsync(bcatId);
            var cat = bcat.Category;
            var model = new DeleteBudgetCategoryVM();
            model.BudgetId = budgetId;
            model.BudgetCategoryId = bcatId;
            model.BudgetCategoryName = cat.CategoryName;
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteBudgetCategory(DeleteBudgetCategoryVM model)
        {
            await bcRepository.DeleteBudgetCategoryAsync(model.BudgetCategoryId);
            return RedirectToAction("Budget", new { budgetId = model.BudgetId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddBudget()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBudget(Budget model)
        {
            var user = await userManager.GetUserAsync(User);
            model.AppUser = user;
            model.BudgetExpenses = new List<Expense>();
            model.BudgetCategories = new List<BudgetCategory>();
            model.BudgetIncomes = new List<Income>();

            await budgetRepository.StoreBudgetsAsync(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteBudget(int budgetId)
        {
            var model = new DeleteBudgetVM();
            model.BudgetId = budgetId;
            var budget = await budgetRepository.GetBudgetByIdAsync(budgetId);

            if (budget.BudgetName == null)
            {
                model.BudgetName = "Budget #" + budget.BudgetId;
            } else
            {
                model.BudgetName = budget.BudgetName;
            }

            model.BudgetCategories = budget.BudgetCategories;
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteBudget(DeleteBudgetVM model)
        {
            await budgetRepository.DeleteBudgetAsync(model.BudgetId);
            return RedirectToAction("Index");
        }
    }
}
