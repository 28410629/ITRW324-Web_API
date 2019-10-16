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
        private readonly IReadingsRepository _ReadingsRepository = new ReadingsRepository(_factory);

        // fetch aggregated sensor reading per station per day.
        public StationDetailDays FetchStationDetailDay(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
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

            Readings = AddZeroEntries<StationDetailDay>.AddHourZeroEntries(Readings);
            
            return new StationDetailDays()
            {
                StationDetails = Readings
            };
        }

        // fetch aggregated sensor reading per station per week.
        public StationDetailDays FetchStationDetailWeek(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
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
            
            Readings = AddZeroEntries<StationDetailDay>.AddDayZeroEntries(Readings);

            return new StationDetailDays()
            {
                StationDetails = Readings
            };
        }

        // fetch aggregated sensor reading per station per month.
        public StationDetailDays FetchStationDetailMonth(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
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

            Readings = AddZeroEntries<StationDetailDay>.AddDayZeroEntries(Readings);
            
            return new StationDetailDays()
            {
                StationDetails = Readings
            };
        }
        
        // fetch aggregated sensor reading per station per year.
        public StationDetailDays FetchStationDetailYear(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
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
            
            Readings = AddZeroEntries<StationDetailDay>.AddMonthZeroEntries(Readings);

            return new StationDetailDays()
            {
                StationDetails = Readings
            };
        }
    }
}