using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q3")]
    public class CubeController : ControllerBase
    {
        /// <summary>
        /// Receives a value and returns the exponent of the value
        /// </summary>
        /// <param name="value">The base number to raise to an exponent
        /// <returns>The result of the typed value raised to the power of the exponent. </returns>
        /// <example>
        /// GET: localhost:5298/api/q3/cube/-4 ->-64
        /// </example>
        /// /{value}
        [HttpGet("cube/{value}")]
        public IActionResult GetCube([FromRoute] int value)
        {
            var result = Math.Pow(value,3);
            return Ok(result);
        }
    }
}