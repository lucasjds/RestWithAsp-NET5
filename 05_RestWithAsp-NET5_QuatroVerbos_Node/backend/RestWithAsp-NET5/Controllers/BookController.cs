using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp_NET5.Business;
using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Hypermedia.Filter;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Authorize("Bearer")]
  [Route("api/[controller]/v{version:apiVersion}")]
  public class BookController : ControllerBase
  {
    private readonly ILogger<BookController> _logger;
    private IBookBusiness _bookBusiness;


    public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
    {
      _logger = logger;
      _bookBusiness = bookBusiness;
    }

    [HttpGet("{sortDirection}/{pageSize}/{page}")]
    [ProducesResponseType(200, Type = typeof(List<BookVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get([FromQuery] string name, string sortDirection, int pageSize, int page)
    {

      return Ok(_bookBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
    }

    [HttpGet]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {

      return Ok(_bookBusiness.FindAll());
    }

    [HttpGet("{id}")]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
      var book = _bookBusiness.FindByID(id);
      if (book == null)
        return NotFound();
      return Ok(book);
    }

    [HttpPost]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] BookVO book)
    {
      if (book == null)
        return BadRequest();
      return Ok(_bookBusiness.Create(book));
    }

    [HttpPut]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] BookVO book)
    {
      if (book == null)
        return BadRequest();
      return Ok(_bookBusiness.Update(book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _bookBusiness.Delete(id);
      return NoContent();
    }
  }
}
