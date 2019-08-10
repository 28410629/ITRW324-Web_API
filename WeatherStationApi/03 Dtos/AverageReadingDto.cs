namespace WeatherStationApi._03_Dtos
{
    public class AverageReadingDto
    {
        public AverageReadingDto() { }

        public AverageReadingDto(int StationId, string AverageTemperature, string AverageHumidity, string AverageAirPressure, string AverageAmbientLight)
        {
            this.StationId = StationId;
            this.AverageTemperature = AverageTemperature;
            this.AverageHumidity = AverageHumidity;
            this.AverageAirPressure = AverageAirPressure;
            this.AverageAmbientLight = AverageAmbientLight;
        }
        
        public int StationId { get; set; }
        
        public string AverageTemperature { get; set; }
        
        public string AverageHumidity { get; set; }
        
        public string AverageAirPressure { get; set; }
        
        public string AverageAmbientLight { get; set; }
    }
}