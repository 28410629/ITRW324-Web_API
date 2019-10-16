using System;
using System.Linq;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class StationDetailService : IStationDetailService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationDetailDays FetchStationDetailDay(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchDayStation(StationId, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month, y.ReadingDateTime.Day, y.ReadingDateTime.Hour})
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature),
                    y.Min(x => x.Temperature),
                    y.Max(x => x.Temperature),
                    y.Average(x => x.Humidity),
                    y.Min(x => x.Humidity),
                    y.Max(x => x.Humidity),
                    y.Average(x => x.AirPressure),
                    y.Min(x => x.AirPressure),
                    y.Max(x => x.AirPressure),
                    y.Average(x => x.AmbientLight),
                    y.Min(x => x.AmbientLight),
                    y.Max(x => x.AmbientLight),
                    new DateTime(y.Key.Year, y.Key.Month, y.Key.Day, y.Key.Hour, 0, 0))
                ).ToList();

            readings = AddZeroEntries<StationDetailDay>.AddHourZeroEntries(readings);
            
            return new StationDetailDays()
            {
                StationDetails = readings
            };
        }

        public StationDetailDays FetchStationDetailWeek(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchWeekStation(StationId, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature),
                    y.Min(x => x.Temperature),
                    y.Max(x => x.Temperature),
                    y.Average(x => x.Humidity),
                    y.Min(x => x.Humidity),
                    y.Max(x => x.Humidity),
                    y.Average(x => x.AirPressure),
                    y.Min(x => x.AirPressure),
                    y.Max(x => x.AirPressure),
                    y.Average(x => x.AmbientLight),
                    y.Min(x => x.AmbientLight),
                    y.Max(x => x.AmbientLight),
                    y.Key)
                ).ToList();
            
            readings = AddZeroEntries<StationDetailDay>.AddDayZeroEntries(readings);

            return new StationDetailDays()
            {
                StationDetails = readings
            };
        }

        public StationDetailDays FetchStationDetailMonth(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchMonthStation(StationId, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature),
                    y.Min(x => x.Temperature),
                    y.Max(x => x.Temperature),
                    y.Average(x => x.Humidity),
                    y.Min(x => x.Humidity),
                    y.Max(x => x.Humidity),
                    y.Average(x => x.AirPressure),
                    y.Min(x => x.AirPressure),
                    y.Max(x => x.AirPressure),
                    y.Average(x => x.AmbientLight),
                    y.Min(x => x.AmbientLight),
                    y.Max(x => x.AmbientLight),
                    y.Key)
                ).ToList();

            readings = AddZeroEntries<StationDetailDay>.AddDayZeroEntries(readings);
            
            return new StationDetailDays()
            {
                StationDetails = readings
            };
        }
        
        public StationDetailDays FetchStationDetailYear(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchYearStation(StationId, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month})
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature),
                    y.Min(x => x.Temperature),
                    y.Max(x => x.Temperature),
                    y.Average(x => x.Humidity),
                    y.Min(x => x.Humidity),
                    y.Max(x => x.Humidity),
                    y.Average(x => x.AirPressure),
                    y.Min(x => x.AirPressure),
                    y.Max(x => x.AirPressure),
                    y.Average(x => x.AmbientLight),
                    y.Min(x => x.AmbientLight),
                    y.Max(x => x.AmbientLight),
                    new DateTime(y.Key.Year, y.Key.Month, 1))
                ).ToList();
            
            readings = AddZeroEntries<StationDetailDay>.AddMonthZeroEntries(readings);

            return new StationDetailDays()
            {
                StationDetails = readings
            };
        }
    }
}