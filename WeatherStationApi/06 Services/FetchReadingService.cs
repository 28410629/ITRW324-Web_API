using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;
using System.Linq;

namespace WeatherStationApi._06_Services
{
    public class FetchReadingService : IFetchReadingService
    {
        private static DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingRepository readingRepository = new ReadingRepository(_factory);

        public ReadingsDto FetchReading(long ReadingId)
        {
            var readings =  readingRepository
                .FetchReading(ReadingId)
                .Select(reading => new ReadingDto(reading));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
    }
} 