using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._06_Services
{
    public class SaveReading
    {
        public void CreateNewReading(ReadingDto reading)
        {
            int Id = Convert.ToInt32(reading.Station);
            
        }
    }
}