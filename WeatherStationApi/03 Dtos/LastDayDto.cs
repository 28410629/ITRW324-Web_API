using Newtonsoft.Json;
using System;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._03_Dtos
{

    public class LastDayDto
    {
        public LastDayDto() { }

        public LastDayDto(int id, string temp, string hum, string press, string light)
        {
            this.StationId = id;
            this.Temperature = temp;
            this.Humidity = hum;
            this.AirPressure = press;
            this.AmbientLight = light;
        }

        [JsonProperty("StationId")]
        public int StationId { get; set; }

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