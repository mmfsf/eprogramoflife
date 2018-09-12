using epl.core.Domain;
using epl.core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace epl.infrastructure
{
  public class CommitmentsContext : DbContext
  {
    public CommitmentsContext(DbContextOptions<CommitmentsContext> options) : base(options) { }

    public DbSet<Commitment> Commitments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Commitment>()
        .HasMany<IDictionary<string, Level>>("Performed");
    }
  }
}
