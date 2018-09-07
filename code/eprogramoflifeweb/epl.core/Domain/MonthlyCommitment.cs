using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
  public class MonthlyCommitment : Commitment
  {
    public MonthlyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Daily;
    }

    public MonthlyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Daily;
    }

    public override void Point(DateTime date, Level level)
    {
      throw new NotImplementedException();
    }

  }
}
