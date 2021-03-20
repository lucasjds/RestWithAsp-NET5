using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Model;
using RestWithAsp_NET5.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithAsp_NET5.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly MySqlContext _context;

    public UserRepository(MySqlContext context)
    {
      _context = context;
    }

    public User ValidateCredentials(UserVO user)
    {
      var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
      return _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == pass);
    }

    private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
    {
      Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
      Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
      return BitConverter.ToString(hashedBytes);
    }
  }
}
