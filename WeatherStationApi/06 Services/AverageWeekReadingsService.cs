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

        public ReadingsDto AverageWeekReadings()
        {
            var readings = _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7))
                .Select(x => new ReadingDto(x))
                .Average(x => Convert.ToDecimal(x.Temperature));

            var test = new ReadingDto();
            var testy = new ReadingsDto();

            test.Temperature = readings.ToString();
            test.Humidity = "nice";
            test.AirPressure = "nice";
            test.AmbientLight = "nice";
            

            testy.Readings.Add(test);

            return testy;

            /*return new ReadingsDto
            {
                Readings = readings.ToList()
            };*/


        }

    }
}