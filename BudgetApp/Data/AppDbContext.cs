using BudgetApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Budget>? Budgets { get; set; }
        public DbSet<Income>? Incomes { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Expense>? Expenses { get; set; }
    }
}