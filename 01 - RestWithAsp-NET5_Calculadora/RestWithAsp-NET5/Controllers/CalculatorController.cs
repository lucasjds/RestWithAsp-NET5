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
    public IActionResult Get(string firstNumber, string secondNumber)
    {
      if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
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
