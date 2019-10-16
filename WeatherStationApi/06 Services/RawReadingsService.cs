using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class RawReadingsService : IRawReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _ReadingsRepository = new ReadingsRepository(_factory);
        
        // fetch unformatted entries from station Readings for the past day per station.
        public RawReadingsDto FetchRawDayAStationReadings(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
                .FetchDayStation(StationId, Date)
                .Select(y => new RawReadingDto(
                    y.ReadingDateTime,
                    y.AirPressure,
                    y.AmbientLight,
                    y.Humidity,
                    y.Temperature)
                );
            return new RawReadingsDto()
            {
                Readings = Readings.ToList()
            };
        }
        
        // fetch unformatted entries from station Readings for the past week per station.
        public RawReadingsDto FetchRawWeekAStationReadings(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
                .FetchWeekStation(StationId, Date)
                .Select(y => new RawReadingDto(
                    y.ReadingDateTime,
                    y.AirPressure,
                    y.AmbientLight,
                    y.Humidity,
                    y.Temperature)
                );
            return new RawReadingsDto()
            {
                Readings = Readings.ToList()
            };
        }
        
        // fetch unformatted entries from station Readings for the past month per station.
        public RawReadingsDto FetchRawMonthAStationReadings(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
                .FetchMonthStation(StationId, Date)
                .Select(y => new RawReadingDto(
                    y.ReadingDateTime,
                    y.AirPressure,
                    y.AmbientLight,
                    y.Humidity,
                    y.Temperature)
                );
            return new RawReadingsDto()
            {
                Readings = Readings.ToList()
            };
        }
        
        // fetch unformatted entries from station Readings for the past year per station.
        public RawReadingsDto FetchRawYearAStationReadings(int StationId, DateTime Date)
        {
            var Readings =  _ReadingsRepository
                .FetchYearStation(StationId, Date)
                .Select(y => new RawReadingDto(
                    y.ReadingDateTime,
                    y.AirPressure,
                    y.AmbientLight,
                    y.Humidity,
                    y.Temperature)
                );
            return new RawReadingsDto()
            {
                Readings = Readings.ToList()
            };
        }
    }
}