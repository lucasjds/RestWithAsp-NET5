using RestWithAsp_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Repository
{
  public interface IBookRepository
  {
    Book Create(Book person);
    Book FindByID(long id);
    List<Book> FindAll();
    Book Update(Book person);
    void Delete(long id);
    bool Exists(long id);
  }
}
