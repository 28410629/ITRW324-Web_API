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

        public MaxReadingsDto FetchMaxDayAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }
        
        public MaxReadingsDto FetchMaxWeekAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }

        public MaxReadingsDto FetchMaxMonthAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30))
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }
        
        public MaxReadingsDto FetchMaxDayAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }
        
        public MaxReadingsDto FetchMaxWeekAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }
        
        public MaxReadingsDto FetchMaxMonthAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MaxReadingDto(
                    g.Key.ToString(), 
                    g.Max(x => x.Temperature), 
                    g.Max(x => x.Humidity), 
                    g.Max(x => x.AirPressure), 
                    g.Max(x => x.AmbientLight))
                );

            return new MaxReadingsDto()
            {
                MaxReadings = readings.ToList()
            };
        }
    }
}