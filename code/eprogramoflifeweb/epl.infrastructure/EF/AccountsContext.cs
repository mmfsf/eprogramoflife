using epl.core.Domain;
using Microsoft.EntityFrameworkCore;

namespace epl.infrastructure.EF
{
    public class AccountsContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountsContext(DbContextOptions<AccountsContext> options) : base(options) { }
    }
}
