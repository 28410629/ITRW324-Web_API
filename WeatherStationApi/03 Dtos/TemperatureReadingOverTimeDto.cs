using System;

namespace WeatherStationApi._03_Dtos
{
    public class TemperatureReadingOverTimeDto
    {
        public TemperatureReadingOverTimeDto() { }
        
        public TemperatureReadingOverTimeDto(int StationId, string TemperatureReading, DateTime ReadingTime)
        {
            this.StationId = StationId;
            this.TemperatureReading = TemperatureReading;
            this.ReadingTime = ReadingTime;
        }
        
        public int StationId { get; set; }
        
        public string TemperatureReading { get; set; }
        
        public DateTime ReadingTime { get; set; }
    }
}