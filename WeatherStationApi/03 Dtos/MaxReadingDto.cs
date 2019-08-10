using System;

namespace WeatherStationApi._03_Dtos
{
    public class MaxReadingDto
    {
        public MaxReadingDto() { }

        public MaxReadingDto(string StationId, string MaxTemperature, string MaxHumidity, string MaxAirPressure, string MaxAmbientLight)
        {
            this.StationId = StationId;
            this.MaxTemperature = MaxTemperature;
            this.MaxHumidity = MaxHumidity;
            this.MaxAirPressure = MaxAirPressure;
            this.MaxAmbientLight = MaxAmbientLight;
        }
        
        public string StationId { get; set; }
        
        public string MaxTemperature { get; set; }
        
        public string MaxHumidity { get; set; }
        
        public string MaxAirPressure { get; set; }
        
        public string MaxAmbientLight { get; set; }
    }
}