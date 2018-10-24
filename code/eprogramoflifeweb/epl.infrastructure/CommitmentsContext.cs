using epl.core.Domain;
using epl.core.ValuesObjects;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace epl.infrastructure
{
  public class CommitmentsContext : DbContext
  {
    public DbSet<DailyCommitment> DailyCommitment { get; set; }
    public DbSet<WeeklyCommitment> WeeklyCommitment { get; set; }
    public DbSet<MonthlyCommitment> MonthlyCommitment { get; set; }
    public DbSet<YearlyCommitment> YearlyCommitment { get; set; }

    public CommitmentsContext(DbContextOptions<CommitmentsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Commitment>(e =>
      {
        e.HasKey(k => k.Id);

        e.Property(p => p.Performed)
        .HasConversion(
          s => JsonConvert.SerializeObject(s, Formatting.None),
          d => JsonConvert.DeserializeObject<Dictionary<string, Level>>(d));

        e.ToTable("Commitments");
      });

      base.OnModelCreating(builder);
    }
  }
}

public class PerformedConverter : ValueConverter<string, Dictionary<string, Level>>
{
  public PerformedConverter(ConverterMappingHints mappingHints = default) : base(EncryptExpr, DecryptExpr, mappingHints)
  {
  }

  static Expression<Func<Dictionary<string, Level>, string>> DecryptExpr = s => JsonConvert.SerializeObject(s, Formatting.None);
  static Expression<Func<string, Dictionary<string, Level>>> EncryptExpr = d => JsonConvert.DeserializeObject<Dictionary<string, Level>>(d));
}
