using System;

namespace WeatherStationApi._03_Dtos
{
    public class FetchReadingDto
    {
        public FetchReadingDto() { }

        public FetchReadingDto(int StationId, double Temperature, double Humidity, double AirPressure, double AmbientLight, DateTime Date)
        {
            this.StationId = Convert.ToString(StationId);
            this.Temperature = Temperature.ToString();
            this.Humidity = Humidity.ToString();
            this.AirPressure = AirPressure.ToString();
            this.AmbientLight = AmbientLight.ToString();
            this.Date = Date;
        }
        
        public string StationId { get; set; }
        
        public string Temperature { get; set; }
        
        public string Humidity { get; set; }
        
        public string AirPressure { get; set; }
        
        public string AmbientLight { get; set; }
        
        public DateTime Date { get; set; }
    }
}