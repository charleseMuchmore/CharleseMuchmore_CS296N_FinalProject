using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> Index(Budget model)
        {
            var user = await userManager.GetUserAsync(User);
            var userId = userManager.GetUserId(User);
            List<Budget> budgets = budgetRepository.GetBudgets()
                .Where(b => b.AppUser == user)
                .ToList<Budget>();
            return View(budgets);
        }
    }
}
