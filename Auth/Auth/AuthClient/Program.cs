using System;
using System.ServiceModel;
using AuthClient.ServiceReference1;

namespace AuthClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new AuthTestClient("http");
            client.ClientCredentials.UserName.UserName = "TestUser";
            client.ClientCredentials.UserName.Password = "TestUser";
            try
            {
                var name = client.GetAuthName();
                string msg = $"Returned: {name.Name}";
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
