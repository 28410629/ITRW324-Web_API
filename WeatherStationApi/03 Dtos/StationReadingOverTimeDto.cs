using System;
using Newtonsoft.Json;

namespace WeatherStationApi._03_Dtos
{
    public class TemperatureReadingOverTimeDto
    {
        public TemperatureReadingOverTimeDto() { }
        
        public TemperatureReadingOverTimeDto(int StationId, string TemperatureReading, string HumiditiyReading, string AirPressureReading, string AmbientLightReading, DateTime ReadingTime)
        {
            this.StationId = StationId;
            this.TemperatureReading = TemperatureReading;
            this.HumiditiyReading = HumiditiyReading;
            this.AirPressureReading = AirPressureReading;
            this.AmbientLightReading = AmbientLightReading;
            this.ReadingTime = ReadingTime;
        }
        public int StationId { get; set; }
        public string TemperatureReading { get; set; }
        public string HumiditiyReading { get; set; }
        public string AirPressureReading { get; set; }
        public string AmbientLightReading { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}