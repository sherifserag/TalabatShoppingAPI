using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TalabatG02.Core.Entities.Identity;

namespace TalabatG02.APIs.Extentions
{
    public static class UserManagerExtentions
    {
        public static async Task<AppUser> FindUserWithAddressAsync(this UserManager<AppUser> userManager,ClaimsPrincipal currentUser)
        {
            var email = currentUser.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(u=>u.Adress).FirstOrDefaultAsync(u=>u.Email == email);

            return user;
        }
    }
}
