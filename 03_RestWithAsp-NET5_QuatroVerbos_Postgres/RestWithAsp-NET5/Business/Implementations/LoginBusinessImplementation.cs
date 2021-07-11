﻿using RestWithAsp_NET5.Configurations;
using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Repository;
using RestWithAsp_NET5.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Business.Implementations
{
  public class LoginBusinessImplementation : ILoginBusiness
  {
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private TokenConfiguration _configuration;
    private IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
    {
      _configuration = configuration;
      _repository = repository;
      _tokenService = tokenService;
    }

    public TokenVO ValidateCredentials(UserVO userCredentials)
    {
      var user = _repository.ValidateCredentials(userCredentials);
      if (user == null)
      {
        return null;
      }
      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
      };
      var accessToken = _tokenService.GenerateAccessToken(claims);
      var refreshToken = _tokenService.GenerateRefreshToken();

      user.RefreshToken = refreshToken;
      user.RefreshTokenExpireTime = DateTime.Now.AddDays(_configuration.DaysToExpire);

      _repository.RefereshUserInfo(user);

      DateTime createDate = DateTime.Now;
      DateTime expirationDate = createDate.AddDays(_configuration.Minutes);

      return new TokenVO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                    );
    }

    public TokenVO ValidateCredentials(TokenVO token)
    {
      var accessToken = token.AccessToken;
      var refreshToken = token.RefreshToken;

      var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

      var userName = principal.Identity.Name;
      var user = _repository.ValidateCredentials(userName);

      if(user == null ||
        user.RefreshToken != refreshToken ||
        user.RefreshTokenExpireTime <= DateTime.Now)
      {
        return null;
      }

      accessToken = _tokenService.GenerateAccessToken(principal.Claims);
      refreshToken = _tokenService.GenerateRefreshToken();

      user.RefreshToken = refreshToken;

      _repository.RefereshUserInfo(user);

      DateTime createDate = DateTime.Now;
      DateTime expirationDate = createDate.AddDays(_configuration.Minutes);

      return new TokenVO(
                    true,
                    createDate.ToString(DATE_FORMAT),
                    expirationDate.ToString(DATE_FORMAT),
                    accessToken,
                    refreshToken
                    );

    }

    public bool RevokeToken(string userName)
    {
      return _repository.RevokeToken(userName);
    }
  }
}
