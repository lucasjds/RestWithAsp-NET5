using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Model;

namespace RestWithAsp_NET5.Repository
{
  public interface IPersonRepository : IRepository<Person>
  {
    Person Disable(long id);
  }
}
