using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Fibinacci;

public class Function
{

    /// <summary>
    /// A simple function that adds up all of the even fibinacci numbers up to the max number.
    /// If no number is set it will set it to 4,000,000.
    /// </summary>
    /// <param name="maxnum"></param>
    /// <returns></returns>
    /// 
    int num1 = 1;
    int num2 = 2;
    List<int> fibList = new List<int>();
    int maxNum;
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        request.QueryStringParameters.TryGetValue("maxnum", out var maxNumIn);
        maxNumIn = maxNumIn ?? "40";
        maxNum = Int32.Parse(maxNumIn);
        Message message = new Message();
        fibList.Add(num2);
        getNum1();
        message.sum =  fibList.Sum();
        message.maxNum = maxNum;
        message.fibList = fibList;
        fibList = new List<int>();
        num1 = 1;
        num2 = 2;
        return new APIGatewayHttpApiV2ProxyResponse
        {
            Body = JsonConvert.SerializeObject(message),
            StatusCode = 200
        };
        
    }

    private void getNum1()
    {
        int nextNum;
        if (num1 + num2 < maxNum)
        {
            nextNum = num1 + num2;
            num1 = nextNum;
            if (isEven(nextNum))
            {
                fibList.Add(nextNum);
            }
            getNum2();
        }
    }

    private void getNum2()
    {
        int nextNum;
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
