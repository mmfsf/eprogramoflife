using epl.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace epl.infrastructure.EF.Repositories
{
    public class ContextRepository<T> : IRepository<T> where T : class
    {
        private DbContext Context { get; set; }

        public ContextRepository(DbContext context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public T Get(string Id)
        {
            return Context.Find<T>(Id);
        }

        public IList<T> List()
        {
            return Context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _ = Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Remove(string Id)
        {
            Remove(Get(Id));
        }

        public T Update(T entity)
        {
            _ = Context.Update(entity);
            _ = Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
