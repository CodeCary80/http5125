using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/J1")]
    public class DeliveDroidController : ControllerBase
    {
        /// <summary>
        /// To know the final score of a robot  droid's delivery
        /// </summary>
        /// <returns>Returns the score of droid in two cases: well done or inefficient</returns>
        /// <param name="Collisions"> The times when droid collided with obstacles
        /// <param name="Deliveries"> The times when droid successfully made deliveries
        /// <example>
        /// post Collisions=2&Deliveries=5 -> 730
        /// </example>
        [HttpPost("Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PostDelivedroid([FromForm] int Collisions , [FromForm] int Deliveries) 
        {          
               var gainPoints = Deliveries * 50;
               var losePoints = Collisions * 10;
               var totals = gainPoints - losePoints;

               if( Deliveries > Collisions ){
                   totals += 500;
               }
                return Ok(totals);
            }
    }
}