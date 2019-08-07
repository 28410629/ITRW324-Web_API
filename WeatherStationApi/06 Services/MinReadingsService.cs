using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class MinReadingsService : IMinReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto FetchMinDayAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
        
        public ReadingsDto FetchMinWeekAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
        
        public ReadingsDto FetchMinMonthAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
    }
}