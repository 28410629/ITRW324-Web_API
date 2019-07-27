using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class LocationsRepository : EntityFrameworkRepository<Location>, ILocationsRepository
    {
        public LocationsRepository(DataContextFactory factory) : base(factory)
        { }

    }
}