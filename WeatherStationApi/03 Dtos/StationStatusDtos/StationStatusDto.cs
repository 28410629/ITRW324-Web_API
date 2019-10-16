using System;
using Newtonsoft.Json;
using WeatherStationApi._02_Models;

namespace WeatherStationApi._03_Dtos
{
    public class StationStatusDto
    {
        public StationStatusDto() { }

        public StationStatusDto(string stnName, string avgtemp, string mxTemp, string mnTemp, string ambntLight, string hum, string f1, string f2, string f3, string f4)
        {
            StationName = stnName;
            AverageTemp = avgtemp;
            MaxTemp = mxTemp;
            MinTemp = mnTemp;
            AmbientLight = ambntLight;
            Humidity = hum;
            ForecastDay1 = f1;
            ForecastDay2 = f2;
            ForecastDay3 = f3;
            ForecastDay4 = f4;

        }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("AverageTemp")]
        public string AverageTemp { get; set; }

        [JsonProperty("MaxTemp")]
        public string MaxTemp { get; set; }

        [JsonProperty("MinTemp")]
        public string MinTemp { get; set; }

        [JsonProperty("AmbientLight")]
        public string AmbientLight { get; set; }
        
        [JsonProperty("Humidity")]
        public string Humidity { get; set; }
        
        [JsonProperty("ForecastDay1")]
        public string ForecastDay1 { get; set; }
        
        [JsonProperty("ForecastDay2")]
        public string ForecastDay2 { get; set; }
        
        [JsonProperty("ForecastDay3")]
        public string ForecastDay3 { get; set; }
        
        [JsonProperty("ForecastDay4")]
        public string ForecastDay4 { get; set; }
    }
}