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

        public DbSet<Category> Categories { get; set; }

        public DbSet<Mem> Memes { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}
