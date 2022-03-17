using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringAPIDemo.Models
{
    public class AppSeedUsers
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AppSeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task SeedUsersAsync()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = "Lead" });
                await roleManager.CreateAsync(new IdentityRole { Name = "Coach" });
            }

            if (!userManager.Users.Any())
            {
                var jojo = new ApplicationUser
                {
                    FullName = "Jojo Jose",
                    Email = "jojo@cognizant.com",
                    PhoneNumber = "9878987890",
                    Age = 30,
                    UserName = "jojo"
                };
                var sarah = new ApplicationUser
                {
                    FullName = "Sarah Andrew",
                    Email = "sarah@cognizant.com",
                    PhoneNumber = "9878987592",
                    Age = 25,
                    UserName = "sarah"
                };

                await userManager.CreateAsync(jojo, "Jojo@1234");
                await userManager.AddToRoleAsync(jojo, "Lead");

                await userManager.CreateAsync(sarah, "Sarah@123");
                await userManager.AddToRoleAsync(sarah, "Coach");
            }
        }


    }
}
