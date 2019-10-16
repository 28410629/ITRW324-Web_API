using System;
using WeatherStationApi._01_Common.Interfaces;

namespace WeatherStationApi._03_Dtos
{
    public class StationDetailDay: IAddZeroEntries
    {
        public StationDetailDay()
        {
            TemperatureReadingAverage = 0;
            TemperatureReadingMin = 0;
            TemperatureReadingMax = 0;
            HumidityReadingAverage = 0;
            HumidityReadingMin = 0;
            HumidityReadingMax = 0;
            AirPressureReadingAverage = 0;
            AirPressureReadingMin = 0;
            AirPressureReadingMax = 0;
            AmbientLightReadingAverage = 0;
            AmbientLightReadingMin = 0;
            AmbientLightReadingMax = 0;
        }

        public StationDetailDay(int StationId,
            double TemperatureReadingAverage,
            double TemperatureReadingMin,
            double TemperatureReadingMax,
            double HumidityReadingAverage,
            double HumidityReadingMin,
            double HumidityReadingMax,
            double AirPressureReadingAverage,
            double AirPressureReadingMin,
            double AirPressureReadingMax,
            double AmbientLightReadingAverage,
            double AmbientLightReadingMin,
            double AmbientLightReadingMax,
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

        public double TemperatureReadingAverage { get; set; }
        public double TemperatureReadingMin { get; set; }
        public double TemperatureReadingMax { get; set; }
        public double HumidityReadingAverage { get; set; }
        public double HumidityReadingMin { get; set; }
        public double HumidityReadingMax { get; set; }
        public double AirPressureReadingAverage { get; set; }
        public double AirPressureReadingMin { get; set; }
        public double AirPressureReadingMax { get; set; }
        public double AmbientLightReadingAverage { get; set; }
        public double AmbientLightReadingMin { get; set; }
        public double AmbientLightReadingMax { get; set; }
        public DateTime ReadingTime { get; set; }

        public DateTime GetDateTime()
        {
            return ReadingTime;
        }
        
        public void SetDateTime(DateTime ReadingTime)
        {
            this.ReadingTime = ReadingTime;
        }
    }
}