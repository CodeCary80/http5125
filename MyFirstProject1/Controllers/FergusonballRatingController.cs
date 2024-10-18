using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/J22022")]
    public class FergusonballRatingController : ControllerBase
    {
        /// <summary>
        /// To calculate the number of players with a star rating greater than 40 and determines if the team is a gold team
        /// </summary>
        /// <returns>Return the total number of the players who get a start rating greater than 40, followed by a plus sign if someone achieve</returns>
        /// <param name="N">  Total number of players on the team
        /// <param name="points"> The number of oints that the player scored
        /// <param name="fouls"> The number of fouls that the player committed
        /// <example>
        /// POST  curl -X 'POST' \'http://localhost:5298/api/J22022/Fergusonball' \-H 'accept: */*' \-H 'Content-Type: multipart/form-data' \-F 'N=3' \-F 'points=12' \-F 'points=10' \-F 'points=9' \-F 'fouls=4' \-F 'fouls=3' \-F 'fouls=1' -> 3+
        /// </example>
        [HttpPost("Fergusonball")]
        public IActionResult PostFergusonball([FromForm] int N, [FromForm] int[] points, [FromForm] int[] fouls ) 
        { 
            int count = 0;
            int starRating;

            for(int i = 0; i < N; i++){
                starRating = points[i] * 5 - fouls[i] * 3; 
                  if( starRating > 40)
                {
                count++;
                }     
            }
            string result = count.ToString();

            if(count == N)
            {
                result += "+";
            }
          
          return Ok(result);
    }
}
}