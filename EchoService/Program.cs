using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EchoService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(EchoService));
            //Allow with: netsh http add urlacl url=http://+:8080/ user=user
            host.Open();

            Console.WriteLine("Service started");
            Console.ReadLine();
        }
    }
}
