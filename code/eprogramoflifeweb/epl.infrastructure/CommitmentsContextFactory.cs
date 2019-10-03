using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace epl.infrastructure
{
    public class CommitmentsContextFactory : IDesignTimeDbContextFactory<CommitmentsContext>
    {
        public CommitmentsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CommitmentsContext>();
            optionsBuilder.UseSqlServer("Server=LOCALHOST\\SQLEXPRESS;Database=eprogramoflife;User Id=sa;Password=123456;");

            return new CommitmentsContext(optionsBuilder.Options);
        }
    }
}
