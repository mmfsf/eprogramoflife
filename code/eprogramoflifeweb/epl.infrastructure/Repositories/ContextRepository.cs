using epl.core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epl.infrastructure.Repositories
{
    public class ContextRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext Context { get; set; }

        public ContextRepository(DbContext context)
        {
            this.Context = context;
        }

        public T Add(T entity)
        {
            this.Context.Add<T>(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public T Get(int Id)
        {
            return this.Context.Find<T>(Id);
        }

        public IList<T> List()
        {
            return this.Context.Set<T>().ToList<T>();
        }

        public void Remove(T entity)
        {
            this.Context.Remove<T>(entity);
            this.Context.SaveChanges();
        }

        public void Remove(int Id)
        {
            this.Remove(this.Get(Id));
        }

        public T Update(T entity)
        {
            this.Context.Update<T>(entity);
            this.Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}
