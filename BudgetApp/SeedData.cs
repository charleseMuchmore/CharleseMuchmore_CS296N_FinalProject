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


            if (context.Budgets != null && !context.Budgets.Any())
            {
                const string SECRET_PASSWORD = "Password123!";

                //General Categories

                Category cat1 = new() { CategoryName = "Food" };
                Category cat2 = new() { CategoryName = "Rent" };
                Category cat3 = new() { CategoryName = "Utilities" };
                Category cat4 = new() { CategoryName = "Phone" };

                if (context.Categories != null)
                {
                    context.Categories.Add(cat1);
                    context.Categories.Add(cat2);
                    context.Categories.Add(cat3);
                    context.Categories.Add(cat4);
                }
                context.SaveChanges();

                //Katy - fake user
                AppUser user2 = new AppUser { UserName = "Katy" };
                var result = userManager.CreateAsync(user2, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    //Budget
                    Budget budget = new()
                    {
                        AppUser = user2,
                        BudgetExpenses = new List<Expense>(),
                        BudgetCategories = new List<BudgetCategory>(),
                        BudgetIncomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);

                    //Categories
                    BudgetCategory bcat1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat1,
                        Planned = 25
                    };

                    BudgetCategory bcat2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat3,
                        Planned = 200
                    };
                    context.BudgetCategories.Add(bcat1);
                    context.BudgetCategories.Add(bcat2);

                    //Incomes
                    Income income1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 1000,
                        AppUser = user2
                    };
                    context.Incomes.Add(income1);

                    Income income2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 2400,
                        AppUser = user2
                    };
                    context.Incomes.Add(income2);

                    //Expenses
                    Expense expense1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1, 
                        ExpenseAmount = 1000,
                        AppUser = user2
                    };

                    Expense expense2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat2.BudgetCategoryId,
                        BudgetCategory = bcat2,
                        ExpenseAmount = 1500,
                        AppUser = user2
                    };
                    context.Expenses.Add(expense1);
                    context.Expenses.Add(expense2);

                    context.SaveChanges();
                }

                //Dominic - fake user
                AppUser user3 = new AppUser { UserName = "Dominic" };
                result &= userManager.CreateAsync(user3, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    //Budget
                    Budget budget = new()
                    {
                        AppUser = user3,
                        BudgetExpenses = new List<Expense>(),
                        BudgetCategories = new List<BudgetCategory>(),
                        BudgetIncomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);

                    //Categories
                    BudgetCategory bcat1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat2,
                        Planned = 2000
                    };

                    BudgetCategory bcat2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat3,
                        Planned = 500
                    };
                    context.BudgetCategories.Add(bcat1);
                    context.BudgetCategories.Add(bcat2);

                    //Incomes
                    Income income1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 3000,
                        AppUser = user3
                    };
                    context.Incomes.Add(income1);

                    //Expenses
                    Expense expense1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 450,
                        AppUser = user3
                    };
                    Expense expense3 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 320,
                        AppUser = user3
                    };

                    Expense expense2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat2.BudgetCategoryId,
                        BudgetCategory = bcat2,
                        ExpenseAmount = 1500,
                        AppUser = user3
                    };
                    context.Expenses.Add(expense1);
                    context.Expenses.Add(expense2);
                    context.Expenses.Add(expense3);

                    context.SaveChanges();
                }
                

                //Jessica - fake user
                AppUser user4 = new AppUser { UserName = "Jessica" };
                result &= userManager.CreateAsync(user4, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    //Budget
                    Budget budget = new()
                    {
                        AppUser = user4,
                        BudgetExpenses = new List<Expense>(),
                        BudgetCategories = new List<BudgetCategory>(),
                        BudgetIncomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);

                    //Categories
                    BudgetCategory bcat1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat1,
                        Planned = 700
                    };

                    BudgetCategory bcat2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat3,
                        Planned = 400
                    };
                    context.BudgetCategories.Add(bcat1);
                    context.BudgetCategories.Add(bcat2);

                    //Incomes
                    Income income1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 500, 
                        AppUser = user4
                    };

                    Income income2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 850,
                        AppUser = user4
                    };
                    context.Incomes.Add(income1);
                    context.Incomes.Add(income2);

                    //Expenses
                    Expense expense1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 450,
                        AppUser = user4
                    };
                    Expense expense3 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 320,
                        AppUser = user4
                    };

                    Expense expense2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat2.BudgetCategoryId,
                        BudgetCategory = bcat2,
                        ExpenseAmount = 1500,
                        AppUser = user4
                    };
                    context.Expenses.Add(expense1);
                    context.Expenses.Add(expense2);
                    context.Expenses.Add(expense3);

                    context.SaveChanges();
                }

                //Henry - fake user
                AppUser user5 = new AppUser { UserName = "Henry" };
                result &= userManager.CreateAsync(user5, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    //Budget
                    Budget budget = new()
                    {
                        AppUser = user5,
                        BudgetExpenses = new List<Expense>(),
                        BudgetCategories = new List<BudgetCategory>(),
                        BudgetIncomes = new List<Income>(),

                    };
                    context.Budgets.Add(budget);

                    //Categories
                    BudgetCategory bcat1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat4,
                        Planned = 50
                    };

                    BudgetCategory bcat2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        Category = cat1,
                        Planned = 400
                    };
                    context.BudgetCategories.Add(bcat1);
                    context.BudgetCategories.Add(bcat2);

                    //Incomes
                    Income income1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        IncomeAmount = 2500,
                        AppUser = user5
                    };
                    context.Incomes.Add(income1);

                    //Expenses
                    Expense expense1 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 450,
                        AppUser = user5
                    };
                    Expense expense3 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat1.BudgetCategoryId,
                        BudgetCategory = bcat1,
                        ExpenseAmount = 320,
                        AppUser = user5
                    };

                    Expense expense2 = new()
                    {
                        BudgetId = budget.BudgetId,
                        Budget = budget,
                        BudgetCategoryId = bcat2.BudgetCategoryId,
                        BudgetCategory = bcat2,
                        ExpenseAmount = 1500,
                        AppUser = user5
                    };
                    context.Expenses.Add(expense1);
                    context.Expenses.Add(expense2);
                    context.Expenses.Add(expense3);

                    context.SaveChanges();
                }

                //Charlese - dev
                AppUser user1 = new AppUser { UserName = "Charlese" };
                result &= userManager.CreateAsync(user1, SECRET_PASSWORD).Result.Succeeded;
                if (result)
                {
                    _ = userManager.AddToRoleAsync(user1, "Admin").Result.Succeeded;
                }
                user1.ProfilePicture = "empty";
                context.SaveChanges();
            }
        }
    }
}
