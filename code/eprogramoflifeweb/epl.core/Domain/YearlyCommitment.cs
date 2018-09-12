using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
  public class YearlyCommitment : Commitment
  {
    protected override string KeyFormat { get => "yyyy"; }

    public YearlyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Yearly;
    }

    public YearlyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Daily;
    }

    public override Level GetPoint(DateTime date)
    {
      var key = date.Date.ToString(this.KeyFormat);
      return this.Performed.ContainsKey(key) ? this.Performed[key] : Level.NotDone;
    }

    public override void Point(DateTime date, Level level)
    {
      var key = date.Date.ToString(this.KeyFormat);
      if (this.Performed.ContainsKey(key))
      {
        this.Performed[key] = level;
      }
      else
      {
        this.Performed.Add(key, level);
      }
    }

  }
}