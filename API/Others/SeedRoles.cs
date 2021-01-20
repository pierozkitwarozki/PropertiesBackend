using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Others
{
   public class SeedRoles
    {
        public static async Task Seed(RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
            {
                new AppRole { Name = "Admin"},
                new AppRole { Name = "User"},
            };

            foreach(var role in roles)
            {
                 await roleManager.CreateAsync(role);
            }
        }
    }
}