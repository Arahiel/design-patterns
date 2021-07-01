using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(new RasterRenderer());
            Console.WriteLine(triangle.ToString());
            Console.Read();
        }
    }
}
