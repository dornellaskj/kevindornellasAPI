using Microsoft.AspNetCore.Mvc;

namespace KevinDornellasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Multiples : ControllerBase
    {
        [HttpGet(Name = "multiples")]
        public int Get()
        {
            List<int> integerList = new List<int>();
            for(int i = 0; i < 1000; i++)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    integerList.Add(i);
                }
            }
            int returnValue = integerList.Sum();
            return returnValue;
        }
    }
}
