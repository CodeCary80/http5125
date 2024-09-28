using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q1")]
    public class WelcomeMessageController : ControllerBase
    {
        /// <summary>
        /// Returns the greeting for the name
        /// </summary>
        /// <returns>Welcome message </returns>
        /// <example>
        /// GET: localhost:5298/api/q1/welcome -> Welcome to 5125 !
        /// </example>
        [HttpGet("welcome")]
        public IActionResult GetWelcome()
        {
            return Ok("Welcome to 5125 !");
        }
    }
}