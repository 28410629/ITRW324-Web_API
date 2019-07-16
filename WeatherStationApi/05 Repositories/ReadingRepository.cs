using System.Linq;
using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;

namespace WeatherStationApi._05_Repositories
{
    public class ReadingRepository : EntityFrameworkRepository<Reading>, IReadingRepository
    {
        public ReadingRepository(DataContextFactory factory) : base(factory)
        { }

        public IQueryable<Reading> FetchReading(long ReadingId)
        {
            return Entities
                    .Reading
                    .Where(reading => reading.Id == ReadingId);
        }
    }
}
