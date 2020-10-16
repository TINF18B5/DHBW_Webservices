using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ExchangeRateClient client = new ServiceReference1.ExchangeRateClient();
            double rate= client.Rate(ServiceReference1.Currency.Dollar);
            Console.WriteLine("Rate of dollar to euro is:" + rate.ToString());
            Console.ReadLine();
        }
    }
}
