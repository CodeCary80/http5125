using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q2")]
    public class GreetingController : ControllerBase
    {
        /// <summary>
        /// Receives a name and returns the greeting for the name
        /// </summary>
        /// <param name="name">The specific name to get greeting
        /// <returns>Gretting information for the typed name </returns>
        /// <example>
        /// GET: localhost:5298/api/q2/greeting?name= name -> Hi name!
        /// </example>
        [HttpGet("greeting")]
        public IActionResult GetGreeting([FromQuery] string name)
        {
            var inputName  = System.Net.WebUtility.UrlDecode(name);
            return Ok($"Hi {inputName}!");
        }
    }
}