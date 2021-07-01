using System;
using System.Collections.Generic;

namespace Facade
{
    public class MagicSquareGenerator
    {
        public List<List<int>> Generate(int size)
        {
            var generator = new Generator();
            var verifier = new Verifier();

            List<List<int>> list = new List<List<int>>();
            while (!verifier.Verify(list))
            {
                var msq = new List<List<int>>();
                for (var i = 0; i < size; i++)
                {
                    msq.Add(generator.Generate(size));
                }
                var splitter = new Splitter();
                list = splitter.Split(msq);
            }

            return list;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var msg = new MagicSquareGenerator();
            var matrix = msg.Generate(3);
            foreach (var list in matrix)
            {
                foreach (var i in list)
                {
                    Console.Write($"{i},");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}