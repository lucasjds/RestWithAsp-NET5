using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAsp_NET5.Services.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private MySqlContext _context;

    public PersonServiceImplementation(MySqlContext context)
    {
      _context = context;
    }

    public List<Person> FindAll()
    {
      return _context.Persons.ToList();
    }

    public Person FindByID(long id)
    {
      return _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
    }

    public Person Create(Person person)
    {
      try
      {
        _context.Add(person);
        _context.SaveChanges();
      }
      catch(Exception)
      {
        throw;
      }
      return person;
    }

    public Person Update(Person person)
    {
      if (!Exists(person.Id)) return new Person();
      var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(person.Id));
      if (result != null)
      {
        try
        {
          _context.Entry(result).CurrentValues.SetValues(person);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }

      return person;
    }

    public void Delete(long id)
    {
      var result = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
      if (result != null)
      {
        try
        {
          _context.Persons.Remove(result);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    private bool Exists(long id)
    {
      return _context.Persons.Any(x => x.Id.Equals(id));
    }
  }
}
