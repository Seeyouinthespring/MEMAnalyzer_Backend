using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MEMAnalyzer_Backend.DBModels
{
    public class MEMAnalyzerContext : IdentityDbContext<ApplicationUser>
    {
        public MEMAnalyzerContext(DbContextOptions<MEMAnalyzerContext> opt) : base(opt)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
