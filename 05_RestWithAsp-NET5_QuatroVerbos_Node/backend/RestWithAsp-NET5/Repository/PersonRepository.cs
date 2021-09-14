using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Context;
using RestWithAsp_NET5.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Repository
{
  public class PersonRepository : GenericRepository<Person>, IPersonRepository
  {
    public PersonRepository(MySqlContext context) : base(context)
    {
    }

    public Person Disable(long id)
    {
      if (!_context.Persons.Any(p => p.Id.Equals(id)))
        return null;
      var user = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));
      if(user != null)
      {
        user.Enabled = false;
        try
        {
          _context.Entry(user).CurrentValues.SetValues(user);
          _context.SaveChanges();
        }
        catch (Exception)
        {
          throw;
        }
      }
      return user;
    }

    public List<Person> FindByName(string firstName, string lastName)
    {
      if(!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
      {
        return _context.Persons.Where(x => x.FirstName.Contains(firstName)
                                        && x.LastName.Contains(lastName)).ToList();
      }
      else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
      {
        return _context.Persons.Where(
                    p => p.LastName.Contains(lastName)).ToList();
      }
      else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
      {
        return _context.Persons.Where(
                    p => p.FirstName.Contains(firstName)).ToList();
      }
      return null;
    }
  }
}
