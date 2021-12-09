using epl.core.ValuesObjects;
using System;

namespace epl.core.Domain
{
    public class YearlyCommitment : Commitment
    {
        protected override string KeyFormat { get => "yyyy"; }

        public YearlyCommitment(string name) : base(name)
        {
            Frequency = Frequency.Yearly;
        }

        public YearlyCommitment(string name, string description) : base(name, description)
        {
            Frequency = Frequency.Yearly;
        }

        public override Level GetPoint(DateTime date)
        {
            var key = date.Date.ToString(KeyFormat);
            return Performed.ContainsKey(key) ? Performed[key] : Level.NotDone;
        }

        public override void Point(DateTime date, Level level)
        {
            var key = date.Date.ToString(KeyFormat);
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