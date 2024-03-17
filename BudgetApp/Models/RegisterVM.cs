using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter your username")]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; } = string.Empty; 

    }
}
