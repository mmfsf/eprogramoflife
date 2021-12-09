using System;
using System.Collections.Generic;

namespace epl.core.Domain
{
    public class ProgramOfLife
    {
        public string Id { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Ideal { get; set; }
        public string Virtue { get; set; }
        public IList<string> Means { get; set; }
        public DateTime CreatedDate { get; }
        public Deffects Deffects { get; set; }
        public IList<Commitment> Commitments { get; set; }

        public ProgramOfLife(Person person)
        {
            Person = person;
            Means = new List<string>();
            CreatedDate = DateTime.Now;
            Deffects = new Deffects();
            Commitments = new List<Commitment>();
        }
    }
}
