using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NET5.Business;
using RestWithAsp_NET5.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Controllers
{
  [Route("api/[controller]/v{version:apiVersion}")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private ILoginBusiness _loginBusiness;

    public AuthController(ILoginBusiness loginBusiness)
    {
      _loginBusiness = loginBusiness;
    }

    [HttpPost]
    [Route("signin")]
    public IActionResult Signin([FromBody] UserVO user)
    {
      if (user == null)
        return BadRequest("Invalid client request");
      var token = _loginBusiness.ValidateCredentials(user);
      if (token == null)
        return Unauthorized();
      return Ok(user);
    }
  }
}
