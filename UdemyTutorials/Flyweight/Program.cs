using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("alpha beta gamma");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
            Console.ReadKey();
        }
    }
}
