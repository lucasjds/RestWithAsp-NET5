using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CalculatorController : ControllerBase
  {


    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
      _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
      if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Sub(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Div(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Mult(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    [HttpGet("square/{firstNumber}")]
    public IActionResult Square(string firstNumber)
    {
      if (IsNumeric(firstNumber))
      {
        var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid input");
    }

    private decimal ConvertToDecimal(string firstNumber)
    {
      decimal value;
      if(decimal.TryParse(firstNumber, out value))
      {
        return value;
      }
      return 0;
    }

    private bool IsNumeric(string firstNumber)
    {
      double number;
      bool isNumber = double.TryParse(firstNumber,
                                      System.Globalization.NumberStyles.Any,
                                      System.Globalization.NumberFormatInfo.InvariantInfo,
                                      out number);
      return isNumber;
    }
  }
}
