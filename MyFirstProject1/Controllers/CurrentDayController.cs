using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q7")]
    public class CurrentDayController : ControllerBase
    {
        /// <summary>
        /// Returns a string representation of the current date (formatted yyyy-MM-dd), adjusted by {days}
        /// </summary>
        /// <returns>Return a day before or after</returns>
        /// <param name="days">Positive numbers mean one day backward, negative numbers mean one day forward
        /// <example>
        /// http://localhost:5298/api/q7/timemachine?days=-1 -》 the day before today(2024-09-26)
        /// </example>
        [HttpGet("timemachine")]
        public IActionResult GetCurrentDay(int days) 
        {       
               DateTime theday = DateTime.Today.AddDays(days);
               return Ok(theday.ToString("yyyy-MM-dd"));
        }
    }
}