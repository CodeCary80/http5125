using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q6")]
    public class HexagonController : ControllerBase
    {
        /// <summary>
        /// Returns the area of a regular hexagon with side length double {S} using  (3√3 s2)/2
        /// </summary>
        /// <returns>Return the area of a regular hexagon with side length double {S}</returns>
        /// <param name="side">The side of the regular hexagon
        /// <param name="sideLength">Assume side > 0
        /// <example>
        /// http://localhost:5298/api/q6/hexagon?side=1 -> 2.598076211353316
        /// </example>
        [HttpGet("hexagon")]
        public IActionResult GetHexagon(double side) 
        {       
                var sideLength = Math.Abs(side);
                var area = Math.Sqrt(3) * 3 / 2 * Math.Pow(sideLength,2);
                 return Ok(area);
                 
        }
    }
}