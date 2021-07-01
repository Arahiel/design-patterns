using System;

namespace Proxy
{
    public class Program
    {
        static void Main(string[] args)
        {
            var p = new Person(17);
            var rp = new ResponsiblePerson(p);

            Console.WriteLine($"Person: {p.Drink()}");
            Console.WriteLine($"Person: {p.DrinkAndDrive()}");
            Console.WriteLine($"Responsible person: {rp.Drink()}");
            Console.WriteLine($"Responsible person: {rp.DrinkAndDrive()}");
            Console.ReadKey();
        }
    }
}
