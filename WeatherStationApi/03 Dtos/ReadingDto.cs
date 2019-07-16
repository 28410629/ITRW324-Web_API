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
            Station = Convert.ToString(reading.StationId);
            Temperature = reading.Temperature;
            Humidity = reading.Humidity;
            AirPressure = reading.AirPressure;
            Light = reading.Light;
        }

        [JsonProperty("Station")]
        public string Station { get; set; }

        [JsonProperty("Temperature")]
        public string Temperature { get; set; }

        [JsonProperty("Humidity")]
        public string Humidity { get; set; }

        [JsonProperty("AirPressure")]
        public string AirPressure { get; set; }

        [JsonProperty("Light")]
        public string Light { get; set; }
    }
}
