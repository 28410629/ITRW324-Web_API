using Newtonsoft.Json;
using System;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._03_Dtos
{
    public class ReadingDto
    {
        public ReadingDto() { }

        public ReadingDto(Reading reading)
        {
            StationId = Convert.ToString(reading.StationId);
            Temperature = reading.Temperature;
            Humidity = reading.Humidity;
            AirPressure = reading.AirPressure;
            AmbientLight = reading.AmbientLight;
        }

        [JsonProperty("StationId")]
        public string StationId { get; set; }

        [JsonProperty("Temperature")]
        public string Temperature { get; set; }

        [JsonProperty("Humidity")]
        public string Humidity { get; set; }

        [JsonProperty("AirPressure")]
        public string AirPressure { get; set; }

        [JsonProperty("AmbientLight")]
        public string AmbientLight { get; set; }
    }
}