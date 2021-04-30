using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SchoolDbContextFactory : DesignTimeDbContextFactoryBase<SchoolDbContext>
    {
        protected override SchoolDbContext CreateNewInstance(DbContextOptions<SchoolDbContext> options)
        {
            return new SchoolDbContext(options);
        }
    }
}