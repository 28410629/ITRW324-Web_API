using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class AverageWeekReadingsService : IAverageWeekReadingsService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);
        
        private static ReadingDto _averageReadings = new ReadingDto();
        private ReadingsDto _averageReadingsDto = new ReadingsDto();

        public ReadingsDto AverageWeekReadings()
        {
            var temperatureReadings = _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .Average(x => Convert.ToDecimal(x.Temperature));
            
            var humidityReadings = _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .Average(x => Convert.ToDecimal(x.Humidity));
            
            var airPressureReadings = _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .Average(x => Convert.ToDecimal(x.AirPressure));
            
            //_averageReadings.Temperature = temperatureReadings.ToString();
            //_averageReadings.Humidity = humidityReadings.ToString();
            //_averageReadings.AirPressure = airPressureReadings.ToString();
            _averageReadings.AmbientLight = "nice";
            
            _averageReadingsDto.Readings.Add(_averageReadings);

            return _averageReadingsDto;

        }

    }
}