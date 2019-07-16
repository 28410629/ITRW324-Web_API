using System;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class SaveReading : ISaveReading
    {
        private static DataContextFactory _factory = new DataContextFactory();
        
        public void CreateNewReading(ReadingDto reading)
        {
            int StationId = Convert.ToInt32(reading.Station);
        }
    }
}