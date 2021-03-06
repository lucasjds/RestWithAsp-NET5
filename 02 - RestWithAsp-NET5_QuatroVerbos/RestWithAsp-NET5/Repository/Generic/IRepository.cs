using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Base;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Repository
{
  public interface IRepository<T> where T : BaseEntity
  {
    T Create(T item); 
    T FindByID(long id); 
    List<T> FindAll(); 
    T Update(T item); 
    void Delete(long id);
    bool Exists(long id);
  }
}
