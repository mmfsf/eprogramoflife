using System;

namespace epl.core.Domain
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ProgramOfLife ProgramOfLife { get; set; }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - DateOfBirth.Year;
                age -= Convert.ToInt32(DateTime.Now.ToString("MMdd")) >= Convert.ToInt32(DateOfBirth.ToString("MMdd")) ? 0 : 1;
                return age;
            }
        }

        public Person()
        {
            DateOfBirth = DateTime.MinValue;
        }
    }
}
