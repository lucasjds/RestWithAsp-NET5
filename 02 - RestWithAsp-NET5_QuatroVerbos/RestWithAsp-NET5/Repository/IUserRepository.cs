using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Model;

namespace RestWithAsp_NET5.Repository
{
  public interface IUserRepository
  {
    User ValidateCredentials(UserVO user);
    User RefereshUserInfo(User user);
  }
}
