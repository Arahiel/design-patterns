using System.Collections.Generic;

namespace Singleton
{
    public interface IDatabase
    {
        List<string> GetCities();
    }
}