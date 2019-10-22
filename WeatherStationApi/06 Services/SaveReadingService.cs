using System;
using WeatherStationApi._02_Models;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class SaveReadingService : ISaveReadingService
    {
        private static DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        // writes a new station reading to the database and commits.
        public void CreateNewReading(ReadingDto reading)
        {
            _readingsRepository.Add(new Reading()
            {
                StationId = Convert.ToInt32(reading.StationId),
                Temperature = Convert.ToDouble(reading.Temperature),
                Humidity = Convert.ToDouble(reading.Humidity),
                AmbientLight = Convert.ToDouble(reading.AmbientLight),
                AirPressure = Convert.ToDouble(reading.AirPressure)
            });
            _readingsRepository.Save();
        }
    }
}