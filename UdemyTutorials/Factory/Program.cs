using System;
using System.Collections.Generic;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();
            List<Person> persons = new List<Person>
            {
                factory.CreatePerson("John"),
                factory.CreatePerson("Adam")
            };

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.Read();
        }
    }
}
