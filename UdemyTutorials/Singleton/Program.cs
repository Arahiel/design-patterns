using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cp1 = Dependency.Container.Resolve<CityProvider>();
            var cp2 = Dependency.Container.Resolve<CityProvider>();

            Console.WriteLine("Are the city provider databases singleton? : " + (cp1.GetDatabase() == cp2.GetDatabase()));
            Console.WriteLine("Are the city providers singleton? : " + (cp1 == cp2));

            Console.WriteLine(cp1.GetCity(0));
            Console.Read();
        }
    }
}
