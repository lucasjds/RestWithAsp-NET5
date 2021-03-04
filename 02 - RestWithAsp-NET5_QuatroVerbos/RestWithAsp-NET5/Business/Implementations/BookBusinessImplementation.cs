using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Business.Implementations
{
  public class BookBusinessImplementation : IBookBusiness
  {
    private readonly IBookRepository _repository;

    public BookBusinessImplementation(IBookRepository repository)
    {
      _repository = repository;
    }

    public List<Book> FindAll()
    {
      return _repository.FindAll();
    }

    public Book FindByID(long id)
    {
      return _repository.FindByID(id);
    }

    public Book Create(Book book)
    {
      return _repository.Create(book);
    }

    public Book Update(Book book)
    {
      return _repository.Update(book);
    }

    public void Delete(long id)
    {
      _repository.Delete(id);
    }
  }
}
