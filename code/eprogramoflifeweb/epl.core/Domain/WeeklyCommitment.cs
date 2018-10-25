using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace epl.core.Domain
{
  public class WeeklyCommitment : Commitment
  {
    protected override string KeyFormat { get => "yyyy"; }

    public WeeklyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Weekly;
    }

    public WeeklyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Weekly;
    }

    public override Level GetPoint(DateTime date)
    {
      var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
      var key = $"{date.ToString(this.KeyFormat)}-{week}";
      return this.Performed.ContainsKey(key) ? this.Performed[key] : Level.NotDone;
    }

    public override void Point(DateTime date, Level level)
    {
      var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
      var key = $"{date.ToString(this.KeyFormat)}-{week}";
      
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
