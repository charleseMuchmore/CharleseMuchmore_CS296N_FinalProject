-- aggregates across budgetcategories for 1 user how much they plan to spend and how much theyve spent so far
SELECT distinct UserName, Sum(bc.planned) as TotalPlanned, Sum(bc.Spent) as TotalSpent
FROM aspnetusers u join budgets b on 
u.Id = b.AppUserId join budgetcategories bc on
b.BudgetId = bc.BudgetId
WHERE u.Id = b.AppUserId and b.BudgetId = bc.BudgetId
GROUP BY UserName;

