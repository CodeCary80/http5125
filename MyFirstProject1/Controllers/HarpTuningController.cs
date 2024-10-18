using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/J32022")]
    public class HarpTuningController : ControllerBase
    {
        public class TuningInput
        {
            public required string Instructions{get;set;}
        }
        
        /// <summary>
        /// Changes all the '+' to "Tighten" and '-' to "Loosen" making tuning instructions easier to read
        /// </summary>
        /// <returns>Returns the Tighten , Loosen, bewtween letters and integers </returns>
        /// <param name="input"> For user to input the tuning instructions
        /// <example>
        /// POST http://localhost:5298/api/J32022/HarpTurning -H "Content-Type: multipart/form-data" -F "Instructions=AFB+8SC-4H-2GDPE+9" -> AFB Tighten 8 SC Loosen 4 H Loosen 2 GDPE Tighten 9

        /// </example>
        [HttpPost("HarpTurning")]
        public IActionResult Postharptuning([FromForm] TuningInput input ) 
        {   
            var output = new StringBuilder();
            string instructions = input.Instructions;
            int i = 0;
            int n = instructions.Length;

            while( i < n)
            {
                string letters = "";
                while ( i < n && instructions[i] >= 'A' && instructions[i] <= 'Z'){
                    letters += instructions[i];
                    i++;
                }
                string action = "";
                if( i < n && (instructions[i] == '+' || instructions[i] == '-')){
                    action = instructions[i] == '+' ? "Tighten" : "Loosen";
                    i++;
                }
                string stringTurns = "";
                if(i < n && instructions[i] >= '0' && instructions[i] <= '9'){
                    stringTurns += instructions[i];
                    i++;
                }
                int turns = int.Parse(stringTurns);

                 output.Append($"{letters} {action} {turns} ");
            
            }
            string resultFormatting = output.ToString().Trim();
            return Ok(resultFormatting);
    }
}
}