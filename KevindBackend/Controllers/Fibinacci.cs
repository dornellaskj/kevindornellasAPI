using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KevinDornellasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Fibinacci : ControllerBase
    {
        int num1 = 1;
        int num2 = 2;
        int maxNum = 4000000;
        List<int> fibList = new List<int>();
        [HttpGet(Name = "fibinacci")]
        public int Get()
        {
            fibList.Add(num2);
            getNum1();
            return fibList.Sum();
        }

        private void getNum1()
        {
            int nextNum = 0;
            if(num1 + num2 < maxNum)
            {
                nextNum = num1 + num2;
                num1 = nextNum;
                if(isEven(nextNum))
                {
                    fibList.Add(nextNum);
                }
                getNum2();
            }
        }

        private void getNum2()
        {
            int nextNum = 0;
            if (num1 + num2 < maxNum)
            {
                nextNum = num1 + num2;
                num2 = nextNum;
                if (isEven(nextNum))
                {
                    fibList.Add(nextNum);
                }
                getNum1();
            }
        }

        private Boolean isEven(int num)
        {
            return num % 2 == 0;
        }
    }
}
