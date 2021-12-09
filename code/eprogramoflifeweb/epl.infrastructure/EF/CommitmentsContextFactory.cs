using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace epl.infrastructure.EF
{
    public class CommitmentsContextFactory : IDesignTimeDbContextFactory<CommitmentsContext>
    {
        public CommitmentsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CommitmentsContext>();
            optionsBuilder.UseSqlServer("Server=LOCALHOST:1433;Database=eprogramoflife;User Id=sa;Password=159753!@;");

            return new CommitmentsContext(optionsBuilder.Options);
        }
    }
}
