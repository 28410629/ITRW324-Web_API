using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;
using System.Linq;

namespace WeatherStationApi._06_Services
{
    public class FetchReadingsService : IFetchReadingsService
    {
        
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        // fetch all readings from the database.
        public FetchReadingsDto FetchReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Select(x => new FetchReadingDto(x.StationId, x.Temperature, x.Humidity, x.AirPressure, x.AmbientLight, x.ReadingDateTime));

            return new FetchReadingsDto
            {
                Readings = readings.ToList()
            };
        }
    }
} 