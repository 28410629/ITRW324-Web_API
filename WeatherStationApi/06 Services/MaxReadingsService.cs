using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class MaxReadingsService : IMaxReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto FetchMaxDayAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
        
        public ReadingsDto FetchMaxWeekAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
        
        public ReadingsDto FetchMaxMonthAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30))
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
    }
}