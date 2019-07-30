using epl.core.Interfaces;
using System;

namespace epl.core.Domain
{
    public class Account : IEntity
    {
        public int ID { get; }

        public string Email { get; }

        public Account(int ID, string email)
        {
            this.ID = ID;
            Email = email;
        }
    }
}
