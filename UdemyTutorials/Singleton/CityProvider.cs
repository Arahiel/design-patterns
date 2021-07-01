using System.Linq;

namespace Singleton
{
    public class CityProvider : IProvider
    {
        private readonly IDatabase _database;

        public CityProvider(IDatabase database)
        {
            _database = database;
        }

        public string GetCity(int index)
        {
            return _database.GetCities()[index];
        }

        public IDatabase GetDatabase() => _database;
    }
}