using epl.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace epl.core.Domain
{
    public class Person : IEntity
    {
        public int ID { get; set; }
        public Account Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - DateOfBirth.Year;
                age -= Convert.ToInt32(DateTime.Now.ToString("MMdd")) >= Convert.ToInt32(DateOfBirth.ToString("MMdd")) ? 0 : 1;
                return age;
            }
        }

        public Person(Account account)
        {
            Account = account;
            DateOfBirth = DateTime.MinValue;
        }
    }
}
