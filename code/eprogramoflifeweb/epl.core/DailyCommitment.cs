using System;
using System.Collections.Generic;
using System.Text;
using epl.core.ValuesObjects;

namespace epl.core
{
    public class DailyCommitment : Commitment
    {
        public DailyCommitment(string name) : base(name)
        {
            this.Frequency = Frequency.Daily;
        }

        public DailyCommitment(string name, string description) : base(name, description)
        {
            this.Frequency = Frequency.Daily;
        }

        public override void Point(DateTime date, Level level)
        {
            throw new NotImplementedException();
        }

    }
}
