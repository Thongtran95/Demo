using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoRepository.Data
{
    public class Initializer
    {
        public static async Task initial(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("user"))
            {
                var users = new IdentityRole("user");
                await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("manager"))
            {
                var users = new IdentityRole("manager");
                await roleManager.CreateAsync(users);
            }
        }
    }
}