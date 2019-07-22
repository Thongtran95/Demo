using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Data.Model
{
    public class ApplicationIdentityDbcontext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbcontext(DbContextOptions<ApplicationIdentityDbcontext> options)
            : base(options)
        {
            
        }
    }
}