using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/J2")]
    public class ChiliPeppersController : ControllerBase
    {
        /// <summary>
        /// To calculate the total SHUs based on different combinations of peppers everytime
        /// </summary>
        /// <returns>Return the total SHUs in each case</returns>
        /// <param name="Ingredient"> list of different peppers including names and SHUs
        /// <example>
        /// GET  curl -X 'GET' "http://localhost:5298/api/J2/ChiliPepper?Ingredient=Poblano,Mirasol,Serrano,Cayenne,Thai,Habanero,Serrano" -> 278500
        /// </example>
        [HttpGet("ChiliPepper")]
        public IActionResult GetChiliPepper(string Ingredient ) 
        { 

        var totalSHU = 0;

        Dictionary<string, int> SHU = new Dictionary<string, int>(){
        {"Poblano" , 1500},
        {"Mirasol" , 6000},
        {"Serrano" , 15500},
        {"Cayenne" , 40000},
        {"Thai" , 75000},
        {"Habanero" , 125000},
        };

        var pepperList = Ingredient.Split(',');

        foreach (var peppers in pepperList){ 
            var addPeppers = peppers.Trim();
            if(SHU.ContainsKey(addPeppers))
            {
            totalSHU += SHU[addPeppers];
            }
        }
         return Ok(totalSHU);
    }
}
}