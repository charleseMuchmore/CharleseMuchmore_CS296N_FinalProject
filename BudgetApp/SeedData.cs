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

                //Charlese - dev
                AppUser user1 = new AppUser { UserName = "Charlese" };
                var result = userManager.CreateAsync(user1, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    _ = userManager.AddToRoleAsync(user1, "Admin").Result.Succeeded;
                }

                //Katy - fake user
                AppUser user2 = new AppUser { UserName = "Katy" };
                result &= userManager.CreateAsync(user2, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    Budget budget = new()
                    {
                        AppUser = user2,
                        Expenses = new List<Expense>(),
                        Categories = new List<Category>(),
                        Incomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);
                }
                context.SaveChanges();

                //Dominic - fake user
                AppUser user3 = new AppUser { UserName = "Dominic" };
                result &= userManager.CreateAsync(user3, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    Budget budget = new()
                    {
                        AppUser = user3,
                        Expenses = new List<Expense>(),
                        Categories = new List<Category>(),
                        Incomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);
                }
                context.SaveChanges();

                //Jessica - fake user
                AppUser user4 = new AppUser { UserName = "Jessica" };
                result &= userManager.CreateAsync(user4, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    Budget budget = new()
                    {
                        AppUser = user4,
                        Expenses = new List<Expense>(),
                        Categories = new List<Category>(),
                        Incomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);
                }
                context.SaveChanges();

                //Henry - fake user
                AppUser user5 = new AppUser { UserName = "Henry" };
                result &= userManager.CreateAsync(user5, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    Budget budget = new()
                    {
                        AppUser = user5,
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
