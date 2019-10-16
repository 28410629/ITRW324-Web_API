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

        public string StationName { get; set; }
        
        public string AverageTemp { get; set; }
        
        public string MaxTemp { get; set; }
        
        public string MinTemp { get; set; }
        
        public string AmbientLight { get; set; }
        
        public string Humidity { get; set; }
        
        public string ForecastDay1 { get; set; }
        
        public string ForecastDay2 { get; set; }
        
        public string ForecastDay3 { get; set; }
        
        public string ForecastDay4 { get; set; }
    }
}