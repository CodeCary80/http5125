using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q4")]
    public class KnockKnockJokeController : ControllerBase
    {
        /// <summary>
        /// Initiate a knockknockjoke controller to get response: "who's there"
        /// </summary>
        /// <returns>A string line : "who's there?" </returns>
        /// <example>
        /// Post: api/q4/knockknock
        /// HEADER: none
        /// BODY: none
        /// -> retruns: "who's there?"
        /// curl -H doesn't exist -d'' 'http://localhost:5298/api/q4/knockknock'
        /// </example>
        [HttpPost("knockknock")]
        public IActionResult PostKnockknock()
        { 
            return Ok("Who's there?");
        }
    }
}