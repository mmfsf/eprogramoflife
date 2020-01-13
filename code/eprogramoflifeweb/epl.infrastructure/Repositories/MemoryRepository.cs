using epl.core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace epl.infrastructure.Repositories
{
    public class MemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly List<T> items;

        public MemoryRepository()
        {
            items = new List<T>();
        }
        public T Add(T entity)
        {
            items.Add(entity);
            return entity;
        }

        public T Get(int ID)
        {
            return items.FirstOrDefault(x => x.ID == ID);
        }

        public IList<T> List()
        {
            return items.AsReadOnly();
        }

        public void Remove(T entity)
        {
            items.Remove(entity);
        }

        public void Remove(int ID)
        {
            var item = this.Get(ID);
            this.Remove(item);
        }

        public T Update(T entity)
        {
            this.Remove(entity);
            this.Add(entity);

            return entity;
        }

        public void Dispose()
        {
            items.Clear();
        }
    }
}
