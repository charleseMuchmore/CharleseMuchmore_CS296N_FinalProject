using BudgetApp.Models;
using BudgetApp.Data;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp
{
    public class SeedData
    {
        public static void Seed(AppDbContext context, IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
            if (adminRole == null)
            {
                _ = roleManager.CreateAsync(new IdentityRole("Admin")).Result.Succeeded;
            }


            if (!context.Budgets.Any())
            {
                const string SECRET_PASSWORD = "Password123!";
                AppUser user1 = new AppUser { UserName = "Charlese" };
                var result = userManager.CreateAsync(user1, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    _ = userManager.AddToRoleAsync(user1, "Admin").Result.Succeeded;
                }
                AppUser user2 = new AppUser { UserName = "All" };
                result &= userManager.CreateAsync(user2, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    Budget budget = new()
                    {
                        AppUser = user1,
                        Expenses = new List<Expense>(),
                        Categories = new List<Category>(),
                        Incomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);
                }
                context.SaveChanges();
            }
        }
    }
}
