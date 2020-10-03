using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlindDating
{
    public static class SetupSecurity
    {
        static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser admin = userManager.FindEmailAsync("admin@blinddating.com").Result;

            if (admin == null)
            {
                IdentityUser sysadmin = new IdentityUser();
                sysadmin.Email = "admin@blinddating.com";
                sysadmin.UserName = " admin@blinddating.com";

                IdentityResult result = userManager.CreateAsync(sysadmin, "@admin1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(sysadmin, "Adminstrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistAsync("NormalUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "NormalUser";
                IdentityResult roleResult = roleManager;
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExsistsAsync("Adminsitrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Adminstrator";
                CreateAsync(role).Result;
            }
        }
    }
}
