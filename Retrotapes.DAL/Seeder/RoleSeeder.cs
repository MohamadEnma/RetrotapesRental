using Microsoft.AspNetCore.Identity;
using Retrotapes.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Seeder
{
    public class RoleSeeder
    {
        public static async Task SeedAdminRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Ensure Admin role exists
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Assign Admin role to user
            var user = await userManager.FindByEmailAsync("mohamad.enma@outlook.com");
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }


    }
}