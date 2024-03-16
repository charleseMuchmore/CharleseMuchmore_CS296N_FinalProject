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
        UserManager<AppUser> userManager;
        public BudgetController(UserManager<AppUser> userMngr, IBudgetRepository br)
        {
            userManager = userMngr;
            budgetRepository = br;
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

            return View(model);
        }
    }
}
