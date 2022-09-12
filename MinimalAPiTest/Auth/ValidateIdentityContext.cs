using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPiTest.Auth
{
    public class ValidateIdentityContext: IdentityDbContext<IdentityUser>
    {
        public ValidateIdentityContext(DbContextOptions<ValidateIdentityContext> options) : base(options)
        { 
        }
        protected ValidateIdentityContext(DbContextOptions  options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
