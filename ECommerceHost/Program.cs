using EntityFramework.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ItemRepository)))
            {
                //Address
                string address = "http://" + Dns.GetHostName() + ":8081/ECommerce";

                //example of A.B.C this is ordered C.B.A here though
                host.AddServiceEndpoint(typeof(IItemRepository), new BasicHttpBinding(), address);

                host.Open();

                Console.WriteLine("Press any key to stop");
                Console.ReadLine();
            }
        }
    }
}
