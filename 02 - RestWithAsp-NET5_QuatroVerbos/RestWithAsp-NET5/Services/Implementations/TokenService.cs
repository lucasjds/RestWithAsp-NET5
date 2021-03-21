using Microsoft.IdentityModel.Tokens;
using RestWithAsp_NET5.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Services.Implementations
{
  public class TokenService : ITokenInterface
  {
    private TokenConfiguration _tokenConfiguration;

    public TokenService(TokenConfiguration tokenConfiguration)
    {
      _tokenConfiguration = tokenConfiguration;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
      var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

      var tokenOptions = new JwtSecurityToken(
          issuer: _tokenConfiguration.Issuer,
          audience: _tokenConfiguration.Audience,
          claims : claims,
          expires : DateTime.Now.AddMinutes(_tokenConfiguration.Minutes),
          signingCredentials: signinCredentials
        );
      return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public string GenerateRefreshToken()
    {
      throw new NotImplementedException();
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
      throw new NotImplementedException();
    }
  }
}
