﻿using epl.core.Domain;
using epl.core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

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
          d => JsonConvert.SerializeObject(d, Formatting.None),
          s => JsonConvert.DeserializeObject<Dictionary<string, Level>>(s));

        e.ToTable("Commitments");
      });

      base.OnModelCreating(builder);
    }
  }
}
