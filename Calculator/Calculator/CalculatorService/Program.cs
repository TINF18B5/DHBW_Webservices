using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Calculator));
            //Allow with: netsh http add urlacl url=http://+:8080/ user=user
            host.Open();
            
            Console.WriteLine("Service started");
            Console.ReadLine();
        }
    }
}
