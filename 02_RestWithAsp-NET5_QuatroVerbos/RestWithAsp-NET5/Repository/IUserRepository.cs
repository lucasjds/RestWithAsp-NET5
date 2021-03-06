﻿using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Model;

namespace RestWithAsp_NET5.Repository
{
  public interface IUserRepository
  {
    User ValidateCredentials(UserVO user);
    User ValidateCredentials(string userName);
    bool RevokeToken(string userName);
    User RefereshUserInfo(User user);
  }
}
