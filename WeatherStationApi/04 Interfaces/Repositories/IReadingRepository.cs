using System.Linq;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._04_Interfaces.Repositories
{
    public interface IReadingRepository : IRepository<Reading>
    {
        IQueryable<Reading> FetchReading(long ReadingId);
    }
}
