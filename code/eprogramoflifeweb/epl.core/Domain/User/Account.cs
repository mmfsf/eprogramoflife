using epl.core.Interfaces;
using System;

namespace epl.core.Domain
{
    public class Account : IEntity
    {
        public int ID { get; }
        public string Email { get; }
        public string Password { get; set; }

        public Account(int ID, string email, string password)
        {
            this.ID = ID;
            Email = email;
            Password = password;
        }
    }
}
