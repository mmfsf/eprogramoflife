using epl.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
    public class Program : IEntity
    {
        public int ID { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Ideal { get; set; }
        public string Virtue { get; set; }
        public IList<string> Path { get; set; }
        public DateTime CreatedDate { get; }
        public Deffects Deffects { get; set; }

        protected internal Program(Person person)
        {
            Person = person;
            Path = new List<string>();
            CreatedDate = DateTime.Now;
            Deffects = new Deffects();
        }
    }
}
