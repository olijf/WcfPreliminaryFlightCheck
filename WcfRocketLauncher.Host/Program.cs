using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfRocketLauncher.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost service = new ServiceHost(typeof(PreFlightCheckService));
            service.Open();

            Console.WriteLine("Now listening");
            Console.Read();
            service.Close();
        }
    }
}
