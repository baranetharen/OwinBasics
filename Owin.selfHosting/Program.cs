using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin.selfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345/"))
            {
                Console.WriteLine("Listining to port 12345....");
                Console.WriteLine("Press Enter to Stop");
                Console.ReadKey();
            }
           
        }
    }
}