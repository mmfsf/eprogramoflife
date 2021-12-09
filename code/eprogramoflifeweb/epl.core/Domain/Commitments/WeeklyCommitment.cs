using epl.core.ValuesObjects;
using System;
using System.Globalization;

namespace epl.core.Domain
{
    public class WeeklyCommitment : Commitment
    {
        protected override string KeyFormat { get => "yyyy"; }

        public WeeklyCommitment(string name) : base(name)
        {
            Frequency = Frequency.Weekly;
        }

        public WeeklyCommitment(string name, string description) : base(name, description)
        {
            Frequency = Frequency.Weekly;
        }

        public override Level GetPoint(DateTime date)
        {
            var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            var key = $"{date.ToString(this.KeyFormat)}-{week}";
            return Performed.ContainsKey(key) ? this.Performed[key] : Level.NotDone;
        }

        public override void Point(DateTime date, Level level)
        {
            var week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            var key = $"{date.ToString(this.KeyFormat)}-{week}";

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
