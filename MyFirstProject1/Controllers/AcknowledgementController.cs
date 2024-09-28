using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q5")]
    public class AcknowledgementController : ControllerBase
    {
        /// <summary>
        /// Initiate a acknowledgement of the {value} integer controller to get response
        /// </summary>
        /// <returns>A string line + {value} </returns>
        /// <example>
        /// Post: /api/q5/acknowledgement
        /// HEADER: Content-Type: application/json
        /// BODY: 5
        /// -> retruns: "Shh.. the secret is 5"
        /// curl  -H 'Content-Type: application/json' -d "-200" "http://localhost:5298/api/q5/acknowledgement"
        /// </example>
        [HttpPost("acknowledgement")]
        public IActionResult PostAcknowledgement([FromBody] int value)
        { 
            return Ok($"Shh.. the secret is{value}");
        }
    }
}
