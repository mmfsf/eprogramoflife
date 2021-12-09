using System;
using epl.core.ValuesObjects;

namespace epl.core.Domain
{
    public class DailyCommitment : Commitment
    {
        protected override string KeyFormat { get => "yyyyMMdd"; }

        public DailyCommitment(string name) : base(name)
        {
            Frequency = Frequency.Daily;
        }

        public DailyCommitment(string name, string description) : base(name, description)
        {
            Frequency = Frequency.Daily;
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
