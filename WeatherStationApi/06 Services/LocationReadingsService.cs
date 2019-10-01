using System;
using System.Linq;
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
        
        public LocationReadingsDto FetchLocationDetailDay(string province, string city, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.Station.Location.City == city && x.Station.Location.Province == province)
                .Where(x => x.ReadingDateTime >= Date.AddMinutes(-1440))
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month, y.ReadingDateTime.Day, y.ReadingDateTime.Hour})
                .Select(y => new LocationReadingDto(
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
                ).ToList();

            if (readings.Count() >= 2)
            {
                for (int i = 1; i < readings.Count(); i++)
                {
                    if (readings[i-1].ReadingTime.AddHours(1).CompareTo(readings[i].ReadingTime) != 0)
                    {
                        readings.Insert(i, new LocationReadingDto(
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            readings[i-1].ReadingTime.AddHours(1)));
                        --i;
                    }
                }
            }

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

        public LocationReadingsDto FetchLocationDetailWeek(string province, string city, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.Station.Location.City == city && x.Station.Location.Province == province)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new LocationReadingDto(
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
                ).ToList();

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

        public LocationReadingsDto FetchLocationDetailMonth(string province, string city, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.Station.Location.City == city && x.Station.Location.Province == province)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new LocationReadingDto(
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
                ).ToList();

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
        
        public LocationReadingsDto FetchLocationDetailYear(string province, string city, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.Station.Location.City == city && x.Station.Location.Province == province)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month})
                .Select(y => new LocationReadingDto(
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
                ).ToList();

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