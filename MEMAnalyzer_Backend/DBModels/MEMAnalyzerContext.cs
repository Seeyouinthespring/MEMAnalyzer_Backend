using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MEMAnalyzer_Backend.DBModels
{
    public class MEMAnalyzerContext : IdentityDbContext<ApplicationUser>
    {
        public MEMAnalyzerContext(DbContextOptions<MEMAnalyzerContext> opt) : base(opt)
        {
            Database.EnsureCreated();  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-70S4V3O\\SQLEXPRESS;Initial Catalog=memanalyzer;User ID=DESKTOP-70S4V3O\\nickz;Integrated Security=SSPI;Persist Security Info=False");
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
