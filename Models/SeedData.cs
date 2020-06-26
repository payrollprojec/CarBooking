using CarBooking.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBooking.Models
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>());

            if (context.Status.Any()) { }
            else
            {
                await context.Status.AddAsync(new Status { Name = "Pending" });
                await context.Status.AddAsync(new Status { Name = "Approved" });
                await context.Status.AddAsync(new Status { Name = "Rejected" });

                await context.SaveChangesAsync();
            }

            if (context.Users.Any())
            {
                return;
            }
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            await roleManager.CreateAsync(new IdentityRole("admin"));
            await roleManager.CreateAsync(new IdentityRole("customer"));

            var user = new ApplicationUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(user, "123456"); // set password same as username

            await userManager.AddToRoleAsync(user, "admin"); // add superadmin role 
        }
    }
}
