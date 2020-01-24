using epl.core.Interfaces;
using System;

namespace epl.core.Domain
{
    public class Account :  IEntity
    {
        public int ID { get; set; }
        public string Email { get; }
        public string Password { get; set; }
        public bool Enabled { get; set; }

        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Account(int ID, string email, string password) : this(email, password)
        {
            this.ID = ID;
        }
    }
}
