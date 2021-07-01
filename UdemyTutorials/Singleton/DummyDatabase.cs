using System;
using System.Collections.Generic;

namespace Singleton
{
    public class DummyDatabase : IDatabase
    {
        public List<string> GetCities()
        {
            Console.WriteLine("Fake database! Only returning some dummy cities");
            return new List<string>
            {
                "Koszalin",
                "Białogard",
                "Słupsk"
            };
        }
    }
}