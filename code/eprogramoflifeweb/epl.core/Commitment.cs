using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;

namespace epl.core
{
    public abstract class Commitment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Frequency Frequency { get; set; }
        public Level Level { get; set; }

        public Dictionary<string, Level> Performed { get; private set; }

        public Commitment(string name)
        {
            this.Name = name;
            this.Performed = new Dictionary<string, Level>();
        }

        public Commitment(string name, string description) : this(name)
        {
            this.Description = description;
        }

        public abstract void Point(DateTime date, Level level);

        public override bool Equals(object obj)
        {
            return this.Name.Equals(((Commitment)obj).Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Frequency.GetHashCode();
        }

        public static bool operator ==(Commitment a, Commitment b)
        {
            return a.Name.Equals(b.Name);
        }

        public static bool operator !=(Commitment a, Commitment b)
        {
            return !a.Name.Equals(b.Name);
        }
    }
}
