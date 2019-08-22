using System;
using Newtonsoft.Json;

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
        [JsonProperty("StationId")]
        public int StationId { get; set; }
        
        [JsonProperty("Temperature")]
        public string TemperatureReading { get; set; }
        
        [JsonProperty("ReadingDateTime")]
        public DateTime ReadingTime { get; set; }
    }
}