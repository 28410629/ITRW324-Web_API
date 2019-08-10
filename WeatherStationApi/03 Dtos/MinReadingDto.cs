using System;

namespace WeatherStationApi._03_Dtos
{
    public class MinReadingDto
    {
        public MinReadingDto() { }

        public MinReadingDto(string StationId, string MinTemperature, string MinHumidity, string MinAirPressure, string MinAmbientLight)
        {
            this.StationId = Convert.ToString(StationId);
            this.MinTemperature = MinTemperature;
            this.MinHumidity = MinHumidity;
            this.MinAirPressure = MinAirPressure;
            this.MinAmbientLight = MinAmbientLight;
        }
        
        public string StationId { get; set; }
        
        public string MinTemperature { get; set; }
        
        public string MinHumidity { get; set; }
        
        public string MinAirPressure { get; set; }
        
        public string MinAmbientLight { get; set; }
    }
}