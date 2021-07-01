using System;
using System.Collections.Generic;

namespace Composition
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listOfValues = new List<IValueContainer>
            {
                new ManyValues {1, 2, 3},
                new ManyValues {2, 2, 2},
                new SingleValue(1)
            };

            var sum = listOfValues.Sum();
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
