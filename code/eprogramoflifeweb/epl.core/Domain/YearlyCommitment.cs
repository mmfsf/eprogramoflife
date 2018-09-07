using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
  class YearlyCommitment : Commitment
  {
    public YearlyCommitment(string name) : base(name)
    {
      this.Frequency = Frequency.Daily;
    }

    public YearlyCommitment(string name, string description) : base(name, description)
    {
      this.Frequency = Frequency.Daily;
    }

    public override void Point(DateTime date, Level level)
    {
      throw new NotImplementedException();
    }

  }
}