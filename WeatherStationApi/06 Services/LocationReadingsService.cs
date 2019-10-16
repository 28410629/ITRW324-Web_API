using System;
using System.Linq;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class LocationReadingsService : ILocationReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);
        
        public LocationReadingsDto FetchLocationDetailDay(string Province, string City, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchDayLocation(Province, City, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month, y.ReadingDateTime.Day, y.ReadingDateTime.Hour})
                .Select(y => new LocationReadingDto(
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

            readings = AddZeroEntries<LocationReadingDto>.AddHourZeroEntries(readings);

            if (readings.Count == 0)
            {
                return new LocationReadingsDto()
                {
                    Found = 0,
                    Readings = readings
                };
            }
            
            return new LocationReadingsDto()
            {
                Found = 1,
                Readings = readings
            };
        }

        public LocationReadingsDto FetchLocationDetailWeek(string Province, string City, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchWeekLocation(Province, City, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new LocationReadingDto(
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
            
            readings = AddZeroEntries<LocationReadingDto>.AddDayZeroEntries(readings);

            if (readings.Count == 0)
            {
                return new LocationReadingsDto()
                {
                    Found = 0,
                    Readings = readings
                };
            }
            
            return new LocationReadingsDto()
            {
                Found = 1,
                Readings = readings
            };
        }

        public LocationReadingsDto FetchLocationDetailMonth(string Province, string City, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchMonthLocation(Province, City, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new LocationReadingDto(
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
            
            readings = AddZeroEntries<LocationReadingDto>.AddDayZeroEntries(readings);

            if (readings.Count == 0)
            {
                return new LocationReadingsDto()
                {
                    Found = 0,
                    Readings = readings
                };
            }
            
            return new LocationReadingsDto()
            {
                Found = 1,
                Readings = readings
            };
        }
        
        public LocationReadingsDto FetchLocationDetailYear(string Province, string City, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchYearLocation(Province, City, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month})
                .Select(y => new LocationReadingDto(
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
            
            readings = AddZeroEntries<LocationReadingDto>.AddMonthZeroEntries(readings);

            if (readings.Count == 0)
            {
                return new LocationReadingsDto()
                {
                    Found = 0,
                    Readings = readings
                };
            }
            
            return new LocationReadingsDto()
            {
                Found = 1,
                Readings = readings
            };
        }
    }
}