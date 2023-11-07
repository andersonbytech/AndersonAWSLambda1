using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using System.Runtime.CompilerServices;
using System.Transactions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AndersonAWSLambda1;

public class Function
{
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task<string> FunctionHandler(string input, ILambdaContext context)
    {

        var context = new DynamoDBContext(new AmazonDynamoDBClient());
        var user = await context.LoadAsync<User>(input);

        //return input.CalculaAnoNascimento();
    }
}

public class User
{
   public Guid Id { get; set; }
   public string Nome { get; set; }
   
}