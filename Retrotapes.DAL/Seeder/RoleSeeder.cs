using Microsoft.AspNetCore.Identity;
using Retrotapes.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Seeder
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("staff"))
            {
                await roleManager.CreateAsync(new IdentityRole("staff"));
            }
        }

        public static async Task SyncSakilaStaffToIdentity(
            UserManager<ApplicationUser> userManager,
            IEnumerable<Staff> sakilaStaffList)
        {
            foreach (var sakilaStaff in sakilaStaffList)
            {
                var user = await userManager.FindByEmailAsync(sakilaStaff.Email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = sakilaStaff.Email,
                        Email = sakilaStaff.Email,
                        // Map more Sakila staff info if needed (e.g., FirstName, LastName)
                    };
                    var result = await userManager.CreateAsync(user, "TempPassword123!"); // Use secure password handling!
                    if (!result.Succeeded)
                    {
                        // Log or handle creation errors
                        continue;
                    }
                }
                if (!await userManager.IsInRoleAsync(user, "staff"))
                {
                    await userManager.AddToRoleAsync(user, "staff");
                }
            }
        }
    }
}