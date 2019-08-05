using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class AverageWeekReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto AverageWeekReadings()
        {
            var readings = _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime <= DateTime.Now.AddDays(31))
                .Select(x => new ReadingDto(x).Temperature.Average(x));
            
            return new ReadingsDto()
            {
                Readings = readings.ToList();
            };

        }
        
        /*private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto FetchReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Select(x => new ReadingDto(x));

            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }
        
        

        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public ReadingsDto FetchLastDayReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .Select(x => new ReadingDto(x));

            
            return new ReadingsDto
            {
                Readings = readings.ToList()
            };
        }*/
    
    }
}