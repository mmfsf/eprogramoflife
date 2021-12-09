using epl.core.ValuesObjects;
using System;

namespace epl.core.Domain
{
    public class MonthlyCommitment : Commitment
    {
        protected override string KeyFormat { get => "yyyyMM"; }

        public MonthlyCommitment(string name) : base(name)
        {
            Frequency = Frequency.Monthly;
        }

        public MonthlyCommitment(string name, string description) : base(name, description)
        {
            Frequency = Frequency.Monthly;
        }

        public override Level GetPoint(DateTime date)
        {
            var key = date.Date.ToString(this.KeyFormat);
            return Performed.ContainsKey(key) ? this.Performed[key] : Level.NotDone;
        }

        public override void Point(DateTime date, Level level)
        {
            var key = date.Date.ToString(this.KeyFormat);
            if (Performed.ContainsKey(key))
            {
                Performed[key] = level;
            }
            else
            {
                Performed.Add(key, level);
            }
        }
    }
}
