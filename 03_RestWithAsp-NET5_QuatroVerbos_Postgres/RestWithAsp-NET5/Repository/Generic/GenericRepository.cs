using Microsoft.EntityFrameworkCore;
using RestWithAsp_NET5.Model.Base;
using RestWithAsp_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Repository.Generic
{
  public class GenericRepository<T> : IRepository<T> where T : BaseEntity
  {
    protected PostgresContext _context;
    private DbSet<T> dataset;

    public GenericRepository(PostgresContext context)
    {
      _context = context;
      dataset = context.Set<T>();
    }

    public T Create(T item)
    {
      try
      {
        dataset.Add(item);
        _context.SaveChanges();
        return item;
      }
      catch (Exception)
      {
        throw;
      }

    }

    public void Delete(long id)
    {
      var result = dataset.SingleOrDefault(x => x.Id.Equals(id));
      if (result != null)
      {
        try
        {
          dataset.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public bool Exists(long id)
    {
      return dataset.Any(x => x.Id.Equals(id));
    }

    public List<T> FindAll()
    {
      return dataset.ToList();
    }

    public T FindByID(long id)
    {
      return dataset.SingleOrDefault(x => x.Id.Equals(id));
    }

    public List<T> FindWithPagedSearch(string query)
    {
      return dataset.FromSqlRaw<T>(query).ToList();
    }

    public int GetCount(string query)
    {
      var result = string.Empty;
      using(var conn = _context.Database.GetDbConnection())
      {
        conn.Open();
        using(var command = conn.CreateCommand())
        {
          command.CommandText = query;
          result = command.ExecuteScalar().ToString();
        }
      }
      return int.Parse(result);
    }

    public T Update(T item)
    {
      var result = dataset.SingleOrDefault(x => x.Id.Equals(item.Id));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(item);
          _context.SaveChanges();
          return result;
        }
        catch (Exception)
        {
          throw;
        }
      }
      else
      {
        return null;
      }
    }
  }
}
