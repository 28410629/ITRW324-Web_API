using System;
using WeatherStationApi._02_Models;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class StationSaveReadingService : IStationSaveReadingService
    {
        private static DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public void CreateNewReading(ReadingDto reading)
        {
            _readingsRepository.Add(new Reading()
            {
                StationId = Convert.ToInt32(reading.StationId),
                Temperature = reading.Temperature,
                Humidity = reading.Humidity,
                AmbientLight = reading.AmbientLight,
                AirPressure = reading.AirPressure
            });
            _readingsRepository.Save();
        }
    }
}