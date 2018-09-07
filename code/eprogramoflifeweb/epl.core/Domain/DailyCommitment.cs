using System;
using System.Collections.Generic;
using System.Text;
using epl.core.ValuesObjects;

namespace epl.core.Domain
{
  public class DailyCommitment : Commitment
  {
    protected override string KeyFormat { get => "yyyyMMdd"; }

    public DailyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Daily;
    }

    public DailyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Daily;
    }

    public override Level GetPoint(DateTime date)
    {
      var key = date.Date.ToString(this.KeyFormat);
      return this.Performed.GetValueOrDefault(key, Level.NotDone);
    }

    public override void Point(DateTime date, Level level)
    {
      this.Performed.Add(date.Date.ToString(this.KeyFormat), level);
    }

  }
}
