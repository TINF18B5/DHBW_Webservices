using EchoClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EchoServiceClient("BasicHttpBinding_IEchoService");
            client.ClientCredentials.UserName.UserName = "test";
            client.ClientCredentials.UserName.Password = "test";
            try
            {
                var argument = new EchoArgument
                {
                    Argument = "HELLO WORLD",
                };
                var result = client.Echo(argument);
                string msg = $"Sent '{argument.Argument}' GOT '{result.Value}'";
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
