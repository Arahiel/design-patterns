using System;

namespace Prototype
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = new Line(new Point(0, 0), new Point(1, 1));
            var y = x.DeepCopy();
            y.Start = new Point(5,5);

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.Read();
        }
    }
}
