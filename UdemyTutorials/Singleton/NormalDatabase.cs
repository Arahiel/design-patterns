using System;
using System.Collections.Generic;

namespace Singleton
{
    public class NormalDatabase : IDatabase
    {
        public List<string> GetCities()
        {
            Console.WriteLine("Connecting to the database...");
            return new List<string>
            {
                "Warszawa",
                "Meksyk",
                "Berlin"
            };
        }
    }
}