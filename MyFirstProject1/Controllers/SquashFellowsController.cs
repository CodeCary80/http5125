using Microsoft.AspNetCore.Mvc;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("api/q8")]
    public class SqushFellowsController : ControllerBase
    {
        /// <summary>
        /// To know each customer's order, and calcuate your ptofit and inventory
        /// </summary>
        /// <returns>Returns your order for small size and large size, how much you spent on each side, what's the tax, and the total price</returns>
        /// <param name="Small">Order for small size of squashfellows plushies
        /// <param name="Large">Order for large size of squashfellows plushies
        /// <example>
        /// post Small,Large = 100 -> 100 Small @ $25.50 = $2550.00; 100 Large @ $40.50 = $4050.00; Subtotal = $6600.00; Tax = $858.00 HST; Total = $7458.00
        /// </example>
        [HttpPost("squashfellows")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult PostSquashFellows([FromForm] int Small , [FromForm] int Large) 
        {          
                decimal smallPrice = 25.50m;
                decimal largePrice = 40.50m;
                decimal taxRate = 0.13m;


                decimal totalSmallPrice = Math.Round(Small * smallPrice, 2);
                decimal totalLargePrice = Math.Round(Large * largePrice, 2);
                decimal subTotal = Math.Round((Small * smallPrice) + (Large * largePrice), 2); 
                decimal tax = Math.Round(subTotal * taxRate, 2);
                decimal total = Math.Round(subTotal + tax, 2);
               
                string response = $"{Small} Small @ ${smallPrice} = ${totalSmallPrice}; " +
                              $"{Large} Large @ ${largePrice} = ${totalLargePrice}; " +
                              $"Subtotal = ${subTotal};" +
                              $"Tax = ${tax} HST;" +
                              $"Total = ${total}";

                return Ok(response);
            }
    }
}


