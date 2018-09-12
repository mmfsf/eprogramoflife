using System.Linq;

namespace epl.core.Interfaces
{
  public interface IRepository<T> where T : class, IEntity
  {
    T Get(int Id);
    IQueryable<T> List();
    T Add(T entity);
    T Update(T entity);
    void Remove(T entity);
    void Remove(int Id);
  }
}
