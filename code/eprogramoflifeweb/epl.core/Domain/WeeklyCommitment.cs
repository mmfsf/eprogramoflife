using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
  class WeeklyCommitment : Commitment
  {
    public WeeklyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Daily;
    }

    public WeeklyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Daily;
    }

    public override void Point(DateTime date, Level level)
    {
      throw new NotImplementedException();
    }

  }
}
