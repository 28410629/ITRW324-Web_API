using System;
using System.Linq;
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

        public TemperatureReadingsOverTimeDto FetchStationDayTemperatureReadingsOverTime(int stationID)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId == stationID)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }

        public TemperatureReadingsOverTimeDto FetchStationWeekTemperatureReadingsOverTime(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }

        public TemperatureReadingsOverTimeDto FetchStationMonthTemperatureReadingsOverTime(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }
    }
}