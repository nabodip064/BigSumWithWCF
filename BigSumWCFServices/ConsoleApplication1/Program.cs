using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(BigSumWcfService.UserService)))
            {
                serviceHost.Open();
                Console.WriteLine("conetcted to services..");
                Console.ReadLine();
            }
        }
    }
}
