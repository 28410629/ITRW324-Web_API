
using System;

namespace WeatherStationApi._03_Dtos
{
    public class ForecastDto
    {
        public ForecastDto() { }
        
        public ForecastDto(double d, int ReadingDay)
        {
           Day = d;
           this.ReadingDay = ReadingDay;
        }

        public double Day { get; set; }
        public int ReadingDay { get; set; }
    }
}