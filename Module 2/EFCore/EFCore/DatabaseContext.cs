using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=SampleEFDatabase;Persist Security Info=True;User ID=sa;Password=0002aciaiC!");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}