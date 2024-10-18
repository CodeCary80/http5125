using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/J12022")]
    public class CupcakePartyController : ControllerBase
    {
        /// <summary>
        /// To know the leftover of cakes when every classmate get one
        /// </summary>
        /// <returns>Returns the leftover of cakes</returns>
        /// <param name="R"> How many regular boxes here
        /// <param name="S"> How many small boxes here
        /// <example>
        /// post  -d 'R=2&S=5' -> 3
        /// </example>
        [HttpPost("Cupcake")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PostCupcake([FromForm] int R , [FromForm] int S) 
        {      
           var cakesInRegular = R * 8;
           var cakesInSmall = S * 3;
           var leftOver = cakesInRegular + cakesInSmall - 28;
           return Ok(leftOver);     
            }
    }
}