using epl.core.Domain;
using epl.core.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace epl.infrastructure.RavenDb.Repositories
{
    public class AccountRavenRepository : IAsyncRepository<Account>
    {
        private readonly IAsyncDocumentSession session;

        public AccountRavenRepository(IAsyncDocumentSession session)
        {
            this.session = session;
        }

        public async Task<Account> Add(Account entity)
        {
            entity.Id = $"{typeof(Account).Name}|".ToLower();
            await session.StoreAsync(entity);
            await session.SaveChangesAsync();

            return entity;
        }

        public async Task<Account> Update(Account entity)
        {
            await session.StoreAsync(entity);
            await session.SaveChangesAsync();

            return entity;
        }

        public async Task<Account> Get(string Id)
        {
            var entity = await session.LoadAsync<Account>($"{typeof(Account).Name}/{Id}");
            return entity;
        }

        public async Task<IList<Account>> List()
        {
            var list = await session.Query<Account>().ToListAsync();
            return list;
        }

        public void Remove(Account entity)
        {
            session.Delete(entity);
        }

        public void Remove(string Id)
        {
            session.Delete(Id);
        }

        public void Dispose()
        {
            session.Dispose();
        }
    }
}
