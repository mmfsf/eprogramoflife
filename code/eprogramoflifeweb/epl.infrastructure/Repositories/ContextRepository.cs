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
      return entity;
    }

    public T Get(int Id)
    {
      return this.Context.Find<T>(Id);
    }

    public IQueryable<T> List()
    {
      var task = Task.Run(async () => {
        return await this.Context.Query<T>().ToListAsync<T>();
      });

      return task.Result.AsQueryable<T>();
    }

    public void Remove(T entity)
    {
      this.Context.Remove<T>(entity);
    }

    public void Remove(int Id)
    {
      this.Remove(this.Context.Find<T>(Id));
    }

    public T Update(T entity)
    {
      this.Context.Update<T>(entity);
      return entity;
    }
  }
}
