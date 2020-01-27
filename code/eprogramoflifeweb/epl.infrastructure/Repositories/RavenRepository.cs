using epl.core.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epl.infrastructure.Repositories
{
    public class RavenRepository<T> : IAsyncRepository<T> where T : class, IEntity
    {
        private readonly IAsyncDocumentSession session;

        public RavenRepository(IAsyncDocumentSession session)
        {
            this.session = session;
        }

        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            session.Dispose();
        }

        public Task<T> Get(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<T>> List()
        {
            var list = await session.Query<T>().ToListAsync();
            return list;
        }

        public Task Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
