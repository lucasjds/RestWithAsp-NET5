using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Hypermedia.Utils;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Business
{
  public interface IPersonBusiness
  {
    PersonVO Create(PersonVO person);
    PersonVO FindByID(long id);
    List<PersonVO> FindByName(string firstName, string lastName);
    List<PersonVO> FindAll();
    PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    PersonVO Update(PersonVO person); 
    void Delete(long id);
    PersonVO Disable(long id);
  }
}
