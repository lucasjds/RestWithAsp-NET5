using RestWithAsp_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Business
{
  public interface IBookBusiness
  {
    Book Create(Book book);
    Book FindByID(long id);
    List<Book> FindAll();
    Book Update(Book book);
    void Delete(long id);
  }
}
