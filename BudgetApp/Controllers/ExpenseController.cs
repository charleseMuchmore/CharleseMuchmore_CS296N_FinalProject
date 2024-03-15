using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
