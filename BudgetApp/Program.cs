using BudgetApp;
using BudgetApp.Data;
using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString =
    builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IBudgetCategoryRepository, BudgetCategoryRepository>();
builder.Services.AddTransient<IIncomeRepository, IncomeRepository>();
builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Seed(dbContext, scope.ServiceProvider);
}

// create a file upload folder in the web root if it doesn't already exist
var fileUploadFolder = Path.Combine(app.Environment.WebRootPath, FileHelpers.UPLOAD_FOLDER);
if (!Directory.Exists(fileUploadFolder))
{
    Directory.CreateDirectory(fileUploadFolder);
}

app.Run();