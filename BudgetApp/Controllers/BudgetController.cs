using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

            
//            budgetCat.BudgetCategoryId = 0; //default generated
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
    }
}
