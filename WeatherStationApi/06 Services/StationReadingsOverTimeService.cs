using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.CodeAnalysis;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class TemperatureReadingsOverTimeService : ITemperatureReadingOverTimeService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationDetailDays FetchStationDetailDay(int stationID, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.StationId == stationID)
                .Where(x => x.ReadingDateTime >= Date.AddMinutes(-1440))
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month, y.ReadingDateTime.Day, y.ReadingDateTime.Hour})
                .Select(y => new StationDetailDay(
                    stationID,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    new DateTime(y.Key.Year, y.Key.Month, y.Key.Day, y.Key.Hour, 0, 0))
                );
            
            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }

        public StationDetailDays FetchStationDetailWeek(int stationID, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-7) && x.StationId == stationID)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    stationID,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    y.Key)
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }

        public StationDetailDays FetchStationDetailMonth(int stationID, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-31) && x.StationId == stationID)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    stationID,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    y.Key)
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }
        
        public StationDetailDays FetchStationDetailYear(int stationID, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddMonths(-12) && x.StationId == stationID)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month})
                .Select(y => new StationDetailDay(
                    stationID,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    new DateTime(y.Key.Year, y.Key.Month, 1))
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }
    }
}