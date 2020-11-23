using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoapCalcClient.ServiceReference1;

namespace SoapCalcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new CalculatorClient("basicHTTP");
            try
            {
                var argument = new Argument()
                {
                    Arg1 = 12.5,
                    Arg2 = 15.0
                };
                var result = httpClient.Multiply(argument);
                var msg = $"{argument.Arg1} * {argument.Arg2} = { result.Value }";
                Console.WriteLine(msg);

                httpClient.Close();
            }
            catch (Exception e)
            {
                httpClient.Abort();
                Console.WriteLine(e.Message);
            }

            var netTcpClient = new CalculatorClient("netTCP");
            try
            {
                var argument = new Argument()
                {
                    Arg1 = 12.5,
                    Arg2 = 15.0
                };
                var result = netTcpClient.Multiply(argument);
                var msg = $"{argument.Arg1} * {argument.Arg2} = { result.Value }";
                Console.WriteLine(msg);

                netTcpClient.Close();
            }
            catch (Exception e)
            {
                netTcpClient.Abort();
                Console.WriteLine(e.Message);
            }

            var customClient = new CalculatorClient("custom");
            try
            {
                var argument = new Argument()
                {
                    Arg1 = 12.5,
                    Arg2 = 15.0
                };
                var result = customClient.Multiply(argument);
                var msg = $"{argument.Arg1} * {argument.Arg2} = { result.Value }";
                Console.WriteLine(msg);

                customClient.Close();
            }
            catch (Exception e)
            {
                customClient.Abort();
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
