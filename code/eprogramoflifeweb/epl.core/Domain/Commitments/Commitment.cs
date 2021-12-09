using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;

namespace epl.core.Domain
{
    public abstract class Commitment : IEquatable<Commitment>
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public Frequency Frequency { get; protected set; }
        public IDictionary<string, Level> Performed { get; private set; }
        protected abstract string KeyFormat { get; }

        protected Commitment(string name)
        {
            Name = name;
            Performed = new Dictionary<string, Level>();
        }

        protected Commitment(string name, string description) : this(name)
        {
            Description = description;
        }

        public abstract void Point(DateTime date, Level level);
        public abstract Level GetPoint(DateTime date);

        public bool Equals(Commitment other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Commitment);
        }
    }
}
