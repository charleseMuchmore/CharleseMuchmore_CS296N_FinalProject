using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
