using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class AverageReadingsService : IAverageReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);
        
        public AverageReadingsDto FetchAverageDayAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );

            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }
        
        public AverageReadingsDto FetchAverageWeekAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );


            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }

        public AverageReadingsDto FetchAverageMonthAllStationsReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30))
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );


            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }
        
        public AverageReadingsDto FetchAverageDayAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );


            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }
        
        public AverageReadingsDto FetchAverageWeekAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );


            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }
        
        public AverageReadingsDto FetchAverageMonthAStationReadings(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-30) && x.StationId == StationId)
                .GroupBy(g => g.StationId)
                .Select(g => new AverageReadingDto(
                    g.Key, 
                    g.Average(x => x.Temperature).ToString(), 
                    g.Average(x => x.Humidity).ToString(), 
                    g.Average(x => x.AirPressure).ToString(), 
                    g.Average(x => x.AmbientLight).ToString())
                );


            return new AverageReadingsDto()
            {
                AverageReadings = readings.ToList()
            };
        }
    }
}