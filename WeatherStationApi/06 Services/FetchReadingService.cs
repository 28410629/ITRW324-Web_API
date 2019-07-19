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
        private readonly IReadingsRepository readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto FetchReadings()
        {
            var readings =  readingsRepository
                .FetchAll()
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
    }
} 