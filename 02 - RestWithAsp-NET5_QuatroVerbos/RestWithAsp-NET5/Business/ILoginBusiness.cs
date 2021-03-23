using RestWithAsp_NET5.Data.VO;

namespace RestWithAsp_NET5.Business
{
  public interface ILoginBusiness
  {
    TokenVO ValidateCredentials(UserVO user);
  }
}
