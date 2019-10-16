using System;

namespace WeatherStationApi._03_Dtos
{
    public class RawReadingDto
    {
        public RawReadingDto(DateTime Date, double Air_Pressure, double Ambient_Light, double Humidity, double Temperature)
        {
            this.Date = Date;
            this.Air_Pressure = Air_Pressure;
            this.Ambient_Light = Ambient_Light;
            this.Humidity = Humidity;
            this.Temperature = Temperature;
        }
        
        public DateTime Date { get; set; }
        public double Air_Pressure { get; set; }
        public double Ambient_Light { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}