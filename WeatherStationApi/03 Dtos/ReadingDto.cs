using Newtonsoft.Json;

namespace WeatherStationApi._03_Dtos
{
    public class ReadingDto
    {
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
