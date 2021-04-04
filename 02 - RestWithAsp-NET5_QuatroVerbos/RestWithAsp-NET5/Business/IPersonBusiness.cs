using RestWithAsp_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Business
{
  public interface IPersonBusiness
  {
    PersonVO Create(PersonVO person);
    PersonVO FindByID(long id);
    List<PersonVO> FindByName(string firstName, string lastName);
    List<PersonVO> FindAll();
    PersonVO Update(PersonVO person); 
    void Delete(long id);
    PersonVO Disable(long id);
  }
}
