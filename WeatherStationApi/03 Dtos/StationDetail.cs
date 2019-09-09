using System;

namespace WeatherStationApi._03_Dtos
{
    public class StationDetail
    {
        public StationDetail() { }
        
        public StationDetail(int StationId, double TemperatureReading, double HumiditiyReading, double AirPressureReading, double AmbientLightReading, DateTime ReadingTime)
        {
            this.StationId = StationId;
            this.TemperatureReading = TemperatureReading;
            this.HumiditiyReading = HumiditiyReading;
            this.AirPressureReading = AirPressureReading;
            this.AmbientLightReading = AmbientLightReading;
            this.ReadingTime = ReadingTime;
        }
        public int StationId { get; set; }
        public double TemperatureReading { get; set; }
        public double HumiditiyReading { get; set; }
        public double AirPressureReading { get; set; }
        public double AmbientLightReading { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}