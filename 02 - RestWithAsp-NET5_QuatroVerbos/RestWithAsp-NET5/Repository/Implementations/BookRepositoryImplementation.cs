using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Repository.Implementations
{
  public class BookRepositoryImplementation : IBookRepository
  {
    private MySqlContext _context;

    public BookRepositoryImplementation(MySqlContext context)
    {
      _context = context;
    }

    public List<Book> FindAll()
    {
      return _context.Books.ToList();
    }

    public Book FindByID(long id)
    {
      return _context.Books.SingleOrDefault(x => x.Id.Equals(id));
    }

    public Book Create(Book book)
    {
      try
      {
        _context.Add(book);
        _context.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }
      return book;
    }

    public Book Update(Book book)
    {
      if (!Exists(book.Id)) return null;
      var result = _context.Books.SingleOrDefault(x => x.Id.Equals(book.Id));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(book);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }

      return book;
    }

    public void Delete(long id)
    {
      var result = _context.Books.SingleOrDefault(x => x.Id.Equals(id));
      if (result != null)
      {
        try
        {
          _context.Books.Remove(result);
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
      return _context.Books.Any(x => x.Id.Equals(id));
    }
  }
}
