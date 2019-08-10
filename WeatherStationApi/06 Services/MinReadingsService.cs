using System;
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

        public MinReadingsDto FetchMinDayAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }
        
        public MinReadingsDto FetchMinWeekAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }

        public MinReadingsDto FetchMinMonthAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30))
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }
        
        public MinReadingsDto FetchMinDayAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }
        
        public MinReadingsDto FetchMinWeekAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }
        
        public MinReadingsDto FetchMinMonthAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new MinReadingDto(
                    g.Key.ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Temperature)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.Humidity)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AirPressure)).ToString(), 
                    g.Min(x => Convert.ToDecimal(x.AmbientLight)).ToString()
                ));

            return new MinReadingsDto()
            {
                MinReadings = readings.ToList()
            };
        }
    }
}