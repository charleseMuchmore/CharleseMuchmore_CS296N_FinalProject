using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class LoginVM
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ReturnUrl { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
