using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace epl.core.Interfaces
{
    public interface IAsyncRepository<T> : IDisposable where T : class
    {
        Task<T> Get(string Id);
        Task<IList<T>> List();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Remove(T entity);
        void Remove(string Id);
    }
}
