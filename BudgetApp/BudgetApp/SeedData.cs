using BudgetApp.Models;
using BudgetApp.Data;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp
{
    public class SeedData
    {
        public static void Seed(AppDbContext context, IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
            if (adminRole == null)
            {
                _ = roleManager.CreateAsync(new IdentityRole("Admin")).Result.Succeeded;
            }

            IdentityRole accountant = roleManager.FindByNameAsync("Accountant").Result;
            if (accountant == null)
            {
                _ = roleManager.CreateAsync(new IdentityRole("Accountant")).Result.Succeeded;
            }

            //seeding users
            /*           if (!context.Budgets.Any())
                       {

                           //Charlese - dev
                           AppUser user1 = new AppUser { UserName = "Charlese"};
                           var result = userManager.CreateAsync(user1, PASSWORD).Result.Succeeded;
                           if (result)
                           {
                               _ = userManager.AddToRoleAsync(user1, "Admin").Result.Succeeded;
                           }

                           AppUser user2 = new AppUser { UserName = "Katy" };
                           result &= userManager.CreateAsync(user2, PASSWORD).Result.Succeeded;

                           AppUser user3 = new AppUser { UserName = "Dominic" };
                           result &= userManager.CreateAsync(user3, PASSWORD).Result.Succeeded;

                           AppUser user4 = new AppUser { UserName = "Jessica" };
                           result &= userManager.CreateAsync(user4, PASSWORD).Result.Succeeded;

                           AppUser user5 = new AppUser { UserName = "Henry" };
                           result &= userManager.CreateAsync(user5, PASSWORD).Result.Succeeded;

                       }*/

            if (!context.Users.Any())  // this is to prevent adding duplicate data
            {
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();
                AppUser user1 = new AppUser { UserName = "Charlese" };
                AppUser user2 = new AppUser { UserName = "Katy" };
                AppUser user3 = new AppUser { UserName = "Dominic" };
                AppUser user4 = new AppUser { UserName = "Jessica" };
                AppUser user5 = new AppUser { UserName = "Henry" };

                const string SECRET_PASSWORD = "Password123!";
                // Note: we're not using async/await here,
                // just using the Result property to make the call synchronous
                // and Success to check for successful creation of a user
                bool isSuccess = userManager.CreateAsync(user1, SECRET_PASSWORD).Result.Succeeded;
                isSuccess &= userManager.CreateAsync(user2, SECRET_PASSWORD).Result.Succeeded;
                isSuccess &= userManager.CreateAsync(user3, SECRET_PASSWORD).Result.Succeeded;
                isSuccess &= userManager.CreateAsync(user4, SECRET_PASSWORD).Result.Succeeded;
                isSuccess &= userManager.CreateAsync(user5, SECRET_PASSWORD).Result.Succeeded;

                /*
                                if (isSuccess)
                                {
                                    var message1 = new BlogPost
                                    {
                                        Author = user1,
                                        Title = "Why Cats Are Superior to Dogs",
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Venenatis cras sed felis eget velit aliquet sagittis id. Quam quisque id diam vel quam. Id porta nibh venenatis cras. Enim facilisis gravida neque convallis a cras. Et ultrices neque ornare aenean euismod elementum nisi quis eleifend. Nulla facilisi etiam dignissim diam quis. Luctus accumsan tortor posuere ac ut consequat semper viverra nam. Morbi enim nunc faucibus a pellentesque sit amet. Ultricies tristique nulla aliquet enim tortor.\r\n\r\nAliquet sagittis id consectetur purus ut faucibus pulvinar. Quis varius quam quisque id diam vel quam elementum. Non pulvinar neque laoreet suspendisse interdum consectetur libero id. Nunc mattis enim ut tellus elementum sagittis vitae. Risus sed vulputate odio ut enim blandit volutpat. Enim ut tellus elementum sagittis. Dui faucibus in ornare quam viverra orci. Pulvinar sapien et ligula ullamcorper malesuada proin libero nunc consequat. Nec feugiat in fermentum posuere urna. Integer eget aliquet nibh praesent tristique magna. Amet porttitor eget dolor morbi non arcu risus. Elementum eu facilisis sed odio morbi quis commodo odio aenean. Est lorem ipsum dolor sit amet consectetur adipiscing. Magna etiam tempor orci eu lobortis elementum nibh tellus.\r\n\r\nUltricies mi quis hendrerit dolor magna eget. Fringilla phasellus faucibus scelerisque eleifend. Vulputate odio ut enim blandit volutpat. Quis lectus nulla at volutpat diam ut venenatis. Et tortor consequat id porta nibh venenatis cras sed felis. Lorem ipsum dolor sit amet consectetur adipiscing. Ac felis donec et odio pellentesque. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat. Nullam non nisi est sit amet facilisis. Volutpat commodo sed egestas egestas. Dignissim cras tincidunt lobortis feugiat vivamus at.",
                                        Rating = 5,
                                        Date = DateOnly.FromDateTime(DateTime.Now),
                                    };
                                    context.BlogPosts.Add(message1);

                                    var message2 = new BlogPost
                                    {
                                        Author = user2,
                                        Title = "Your Diet and the Feline Diet: Where's the Crossover?",
                                        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Venenatis cras sed felis eget velit aliquet sagittis id. Quam quisque id diam vel quam. Id porta nibh venenatis cras. Enim facilisis gravida neque convallis a cras. Et ultrices neque ornare aenean euismod elementum nisi quis eleifend. Nulla facilisi etiam dignissim diam quis. Luctus accumsan tortor posuere ac ut consequat semper viverra nam. Morbi enim nunc faucibus a pellentesque sit amet. Ultricies tristique nulla aliquet enim tortor.\r\n\r\nAliquet sagittis id consectetur purus ut faucibus pulvinar. Quis varius quam quisque id diam vel quam elementum. Non pulvinar neque laoreet suspendisse interdum consectetur libero id. Nunc mattis enim ut tellus elementum sagittis vitae. Risus sed vulputate odio ut enim blandit volutpat. Enim ut tellus elementum sagittis. Dui faucibus in ornare quam viverra orci. Pulvinar sapien et ligula ullamcorper malesuada proin libero nunc consequat. Nec feugiat in fermentum posuere urna. Integer eget aliquet nibh praesent tristique magna. Amet porttitor eget dolor morbi non arcu risus. Elementum eu facilisis sed odio morbi quis commodo odio aenean. Est lorem ipsum dolor sit amet consectetur adipiscing. Magna etiam tempor orci eu lobortis elementum nibh tellus.\r\n\r\nUltricies mi quis hendrerit dolor magna eget. Fringilla phasellus faucibus scelerisque eleifend. Vulputate odio ut enim blandit volutpat. Quis lectus nulla at volutpat diam ut venenatis. Et tortor consequat id porta nibh venenatis cras sed felis. Lorem ipsum dolor sit amet consectetur adipiscing. Ac felis donec et odio pellentesque. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat. Nullam non nisi est sit amet facilisis. Volutpat commodo sed egestas egestas. Dignissim cras tincidunt lobortis feugiat vivamus at.",
                                        Rating = 8,
                                        Date = DateOnly.FromDateTime(DateTime.Now),
                                    };
                                    context.BlogPosts.Add(message2);

                                    context.SaveChanges();
                                }*/

            }
        }
    }
}
