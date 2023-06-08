using Microsoft.AspNetCore.Mvc;

namespace TestTech.Controllers
{
    public class FibonacciController : Controller
    {
        [HttpGet("fibonacci/{n}")]
        public IActionResult FibonacciAction(int n)
        {
            if (n <= 1 || n >= 100)
            {
                return Ok(-1);
            }

            return Ok(Fibonacci(n));
        }

        private static double Fibonacci(int n)
        {
            double[] memo = new double[n + 1];
            return Fibonacci(n, memo);
        }

        private static double Fibonacci(int n, double[] memo)
        {
            if (n <= 1)
            {
                return n;
            }
            else if (memo[n] > 0)
            {
                return memo[n];
            }

            memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            return memo[n];
        }
    }
}
