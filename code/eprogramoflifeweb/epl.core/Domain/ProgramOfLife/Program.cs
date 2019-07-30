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
        public DateTime CreatedDate { get; }

        public Program(Person person)
        {
            Person = person;
            CreatedDate = DateTime.Now;
        }
    }
}
