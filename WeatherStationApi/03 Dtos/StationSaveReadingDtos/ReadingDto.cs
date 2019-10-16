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
            Temperature = reading.Temperature.ToString();
            Humidity = reading.Humidity.ToString();
            AirPressure = reading.AirPressure.ToString();
            AmbientLight = reading.AmbientLight.ToString();
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