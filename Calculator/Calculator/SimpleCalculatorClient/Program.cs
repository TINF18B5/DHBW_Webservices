using System;
using SimpleCalculatorClient.CalculatorServiceReference;

namespace SimpleCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CalculatorClient();

            var argument = new Argument
            {
                Arg1 = 36,
                Arg2 = 6
            };
            var result = client.Add(argument);
            string msg = $"{argument.Arg1} + {argument.Arg2} = {result.Value}";
            Console.WriteLine(msg);

            Console.ReadLine();
        }
    }
}
