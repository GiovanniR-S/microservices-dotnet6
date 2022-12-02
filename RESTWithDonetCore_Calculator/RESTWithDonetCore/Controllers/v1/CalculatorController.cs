using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTWithDonetCore.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController:ControllerBase {
        private readonly ILogger<CalculatorController> _logger;
        public CalculatorController (ILogger<CalculatorController> logger) {
            _logger = logger;
        }
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get (string firstNumber, string secondNumber) {
            
            return BadRequest("Invalid Input");
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum (string firstNumber, string secondNumber) {
            if(IsNumeric(firstNumber) && IsNumeric(firstNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("mut/{firstNumber}/{secondNumber}")]
        public IActionResult GetMut (string firstNumber, string secondNumber) {
            if(IsNumeric(firstNumber) && IsNumeric(firstNumber)) {
                var mut = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mut.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub (string firstNumber, string secondNumber) {
            if(IsNumeric(firstNumber) && IsNumeric(firstNumber)) {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv (string firstNumber, string secondNumber) {
            if(IsNumeric(firstNumber) && IsNumeric(firstNumber)) {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult GetMed (string firstNumber, string secondNumber) {
            if(IsNumeric(firstNumber) && IsNumeric(firstNumber)) {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                var med = sum / 2; 
                return Ok(med.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("Sqrt/{firstNumber}")]
        public IActionResult GetSqrt (string firstNumber) {
            if(IsNumeric(firstNumber)) {
                var sqrt = Math.Sqrt(ConvertToDouble(firstNumber));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input");
        }
        private double ConvertToDouble (string strNumber) {
            double value;
            if(double.TryParse(strNumber, out value)) {
                return value;
            }
            return 0;
        }
        private decimal ConvertToDecimal (string strNumber) {
            decimal value;
            if(decimal.TryParse(strNumber, out value)) {
                return value;
            }
            return 0;
        }
        private bool IsNumeric (string strNumber) {
            double Number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out Number);

            return isNumber;
        }
    }
}
