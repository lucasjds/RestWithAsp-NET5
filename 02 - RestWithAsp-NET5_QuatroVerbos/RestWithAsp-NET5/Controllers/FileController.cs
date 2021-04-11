using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAsp_NET5.Business;
using RestWithAsp_NET5.Data.VO;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Authorize("Bearer")]
  [Route("api/[controller]/v{version:apiVersion}")]
  public class FileController : Controller
  {
    private readonly IFileBusiness _fileBusiness;

    public FileController(IFileBusiness fileBusiness)
    {
      _fileBusiness = fileBusiness;
    }

    [HttpPost("uploadFile")]
    [ProducesResponseType(200, Type = typeof(FileDetailVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [Produces("application/json")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
      FileDetailVO detail = await _fileBusiness.SaveFileToDisk(file);
      return new OkObjectResult(detail);
    }
  }
}
