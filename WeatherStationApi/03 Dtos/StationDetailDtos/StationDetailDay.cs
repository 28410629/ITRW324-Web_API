using System;

namespace WeatherStationApi._03_Dtos
{
    public class StationDetailDay
    {
        public StationDetailDay() { }
        
        public StationDetailDay(int StationId, 
            string TemperatureReadingAverage, 
            string TemperatureReadingMin,
            string TemperatureReadingMax,
            string HumidityReadingAverage, 
            string HumidityReadingMin, 
            string HumidityReadingMax, 
            string AirPressureReadingAverage, 
            string AirPressureReadingMin, 
            string AirPressureReadingMax,
            string AmbientLightReadingAverage, 
            string AmbientLightReadingMin, 
            string AmbientLightReadingMax, 
            DateTime ReadingTime)
        {
            this.StationId = StationId;
            this.TemperatureReadingAverage = TemperatureReadingAverage;
            this.TemperatureReadingMin = TemperatureReadingMin;
            this.TemperatureReadingMax = TemperatureReadingMax;
            this.HumidityReadingAverage = HumidityReadingAverage;
            this.HumidityReadingMin = HumidityReadingMin;
            this.HumidityReadingMax = HumidityReadingMax;
            this.AirPressureReadingAverage = AirPressureReadingAverage;
            this.AirPressureReadingMin = AirPressureReadingMin;
            this.AirPressureReadingMax = AirPressureReadingMax;
            this.AmbientLightReadingAverage = AmbientLightReadingAverage;
            this.AmbientLightReadingMin = AmbientLightReadingMin;
            this.AmbientLightReadingMax = AmbientLightReadingMax;
            this.ReadingTime = ReadingTime;
        }
        public int StationId { get; set; }
        
        public string TemperatureReadingAverage { get; set; }
        public string TemperatureReadingMin { get; set; }
        public string TemperatureReadingMax { get; set; }
        public string HumidityReadingAverage { get; set; }
        public string HumidityReadingMin { get; set; }
        public string HumidityReadingMax { get; set; }
        public string AirPressureReadingAverage { get; set; }
        public string AirPressureReadingMin { get; set; }
        public string AirPressureReadingMax { get; set; }
        public string AmbientLightReadingAverage { get; set; }
        public string AmbientLightReadingMin { get; set; }
        public string AmbientLightReadingMax { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}