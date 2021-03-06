using RestWithAsp_NET5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Repository.Generic
{
  public class GenericRepository<T> : IRepository<T> where T : BaseEntity
  {
    public T Create(T item)
    {
      throw new NotImplementedException();
    }

    public void Delete(long id)
    {
      throw new NotImplementedException();
    }

    public bool Exists(long id)
    {
      throw new NotImplementedException();
    }

    public List<T> FindAll()
    {
      throw new NotImplementedException();
    }

    public T FindByID(long id)
    {
      throw new NotImplementedException();
    }

    public T Update(T item)
    {
      throw new NotImplementedException();
    }
  }
}
