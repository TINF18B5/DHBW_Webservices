using System;
using System.ServiceModel;
using SimpleCalculatorClient.ServiceReference1;

namespace SimpleCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CalculatorClient("BasicHttpBinding_ICalculator");
            client.ClientCredentials.UserName.UserName = "Hugo";
            client.ClientCredentials.UserName.Password = "hugo";
            try
            {
                var argument = new Argument
                {
                    Arg1 = 36,
                    Arg2 = 6
                };
                var result = client.Add(argument);
                string msg = $"{argument.Arg1} + {argument.Arg2} = {result.Value}";
                Console.WriteLine(msg);
                client.Close();
            }
            catch (Exception e)
            {
                client.Abort();
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
