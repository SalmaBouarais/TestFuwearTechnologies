using Microsoft.AspNetCore.Mvc;

namespace TestTech.Controllers
{
    public class ActionsController : Controller
    {
        [HttpGet("action")]
        public IActionResult Action()
        {
            var actions = new[] { "AMZN", "CACC", "EQIX", "GOOG", "ORLY", "ULTA" };
            var prices = new[,]
            {
                { 12.81, 11.09, 12.11, 10.93, 9.83, 8.14 },
                { 10.34, 10.56, 10.14, 12.17, 13.1, 11.22 },
                { 11.53, 10.67, 10.42, 11.88, 11.77, 10.21 },
            };

            double highestAvgPrice = 0;
            string name = string.Empty;

            for (int i = 0; i < actions.Length; i++)
            {
                double newAvg = 0;
                for (int j = 0; j < prices.GetLength(0); j++)
                {
                    newAvg += prices[j, i];
                }
                newAvg /= prices.GetLength(0);

                if (highestAvgPrice < newAvg)
                {
                    highestAvgPrice = newAvg;
                    name = actions[i];
                }
            }

            return Ok(new { 
                Name = name,
                AvgPrice = highestAvgPrice,
            });
        }
    }
}
