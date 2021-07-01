using System;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon {Age = 2};
            Console.WriteLine("I am a dragon!");
            Console.WriteLine(dragon.Fly());
            Console.WriteLine(dragon.Crawl());

            Console.ReadKey();
        }
    }
}