using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Services.Implementations
{
  public class PersonServiceImplementation : IPersonService
  {
    private MySqlContext _context;

    public PersonServiceImplementation(MySqlContext context)
    {
      _context = context;
    }

    public Person Create(Person person)
    {
      return person;
    }

    public void Delete(long id)
    {

    }

    public List<Person> FindAll()
    {
      return _context.Persons.ToList();
    }


    public Person FindByID(long id)
    {
      return new Person
      {
        Id = 1,
        FirstName = "Lucas",
        LastName = "Souza",
        Address = "Lafaiete",
        Gender = "Male",
      };
    }

    public Person Update(Person person)
    {
      return person ;
    }
  }
}
