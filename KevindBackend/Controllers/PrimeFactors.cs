using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KevinDornellasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeFactors : ControllerBase
    {
        [HttpGet(Name = "prime")]
        public Int64 Get([FromQuery] Int64 number)
        {
            return FindMaxPrime(number);
        }

        private Int64 FindMaxPrime(Int64 number)
        {
            Int64 limit = (long)Math.Ceiling(Math.Sqrt(number));
            for(Int64 i = 2; i <= limit; i++)
            {
                if(number % i == 0)
                {
                    number = number / i;
                    return FindMaxPrime(number);
                }
            }
            return number;
        }

        
    }
}
