using System;
using System.Collections.Generic;

namespace epl.core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(string Id);
        IList<T> List();
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        void Remove(string Id);
    }
}
