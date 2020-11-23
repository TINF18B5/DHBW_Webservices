using System;
using System.ServiceModel;

namespace AuthService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(AuthTest));
            //Allow with: netsh http add urlacl url=http://+:8080/ user=user
            host.Open();

            Console.WriteLine("Service started");
            Console.ReadLine();
        }
    }

    class AuthTest : IAuthTest
    {
        public AuthName GetAuthName()
        {
            var identity = ServiceSecurityContext.Current.PrimaryIdentity;
            return new AuthName() { Name = identity.Name };
        }
    }
}
