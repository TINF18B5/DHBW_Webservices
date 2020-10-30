using System;
using Grpc.Net.Client;
using GRPCCalculator.Protos;

namespace GRPCClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var invoker = channel.CreateCallInvoker();
                Calculator.CalculatorClient client = new Calculator.CalculatorClient(invoker);
                var argument = new Argument() {Arg1 = 36, Arg2 = 6};
                var result = client.Add(argument);
                Console.WriteLine($"{argument.Arg1} + {argument.Arg2} = {result.Result_}");
            }

            Console.ReadLine();
        }
    }
}
