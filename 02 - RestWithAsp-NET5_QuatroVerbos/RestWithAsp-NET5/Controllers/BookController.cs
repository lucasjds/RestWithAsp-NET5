﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAsp_NET5.Business;
using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Hypermedia.Filter;
using RestWithAsp_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Controllers
{
  [ApiVersion("1")]
  [ApiController]
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
