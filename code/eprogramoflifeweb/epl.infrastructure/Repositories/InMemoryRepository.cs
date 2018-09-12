using epl.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace epl.infrastructure.Repositories
{
  public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
  {
    private IList<T> Content { get; set; }

    public InMemoryRepository()
    {
      this.Content = new List<T>();
    }

    public T Add(T entity)
    {
      entity.Id = this.Content.Count + 1;
      this.Content.Add(entity);
      return entity;
    }

    public T Get(int Id)
    {
      return this.Content.FirstOrDefault<T>(x => x.Id == Id);
    }

    public IQueryable<T> List()
    {
      return this.Content.AsQueryable<T>();
    }

    public void Remove(T entity)
    {
      this.Content.Remove(entity);
    }

    public void Remove(int Id)
    {
      this.Remove(this.Get(Id));
    }

    public T Update(T entity)
    {
      var aux = this.Get(entity.Id);
      if(aux != null)
      {
        aux = entity;
      }
      return entity;
    }
  }
}
