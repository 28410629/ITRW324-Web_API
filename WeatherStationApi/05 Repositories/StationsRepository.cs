using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class StationsRepository : EntityFrameworkRepository<Station>, IStationsRepository
    {
        public StationsRepository(DataContextFactory factory) : base(factory)
        { }

    }
}