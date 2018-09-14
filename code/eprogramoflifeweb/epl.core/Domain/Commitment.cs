using epl.core.Interfaces;
using epl.core.ValuesObjects;
using System;
using System.Collections.Generic;

namespace epl.core.Domain
{
  public abstract class Commitment : IEntity, IEquatable<Commitment>
  {
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Description { get; set; }
    public Frequency Frequency { get; protected set; }
    public IDictionary<string, Level> Performed { get; private set; }

    protected abstract string KeyFormat { get; }
    
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
    public abstract Level GetPoint(DateTime date);

    public bool Equals(Commitment other)
    {
      return this.Id == other.Id;
    }
  }
}
