using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace epl.core.Interfaces
{
    public interface IAsyncRepository<T> : IDisposable where T : class, IEntity
    {
        Task<T> Get(int ID);
        Task<IList<T>> List();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Remove(T entity);
        Task Remove(int ID);
    }
}
