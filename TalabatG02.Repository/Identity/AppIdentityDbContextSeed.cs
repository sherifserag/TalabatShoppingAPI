using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Identity;

namespace TalabatG02.Repository.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Nasser",
                    Email = "ahmed.Nasser@gmail.com",
                    UserName = "Ahmed.Nasser",
                    PhoneNumber = "01271155277"
                };
                await userManager.CreateAsync(user,"P@ssw0rd");
            }
        }
    }
}
