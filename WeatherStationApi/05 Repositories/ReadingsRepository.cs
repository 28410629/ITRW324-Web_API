using System.Linq;
using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class ReadingsRepository : EntityFrameworkRepository<Reading>, IReadingsRepository
    {
        public ReadingsRepository(DataContextFactory factory) : base(factory)
        { }

    }
}
