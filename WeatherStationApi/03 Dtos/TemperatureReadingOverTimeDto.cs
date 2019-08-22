namespace WeatherStationApi._03_Dtos
{
    public class TemperatureReadingOverTimeDto
    {
        public TemperatureReadingOverTimeDto() { }
        
        public TemperatureReadingOverTimeDto(int StationId, string TemperatureReading, string ReadingTime)
        {
            this.StationId = StationId;
            this.TemperatureReading = TemperatureReading;
            this.ReadingTime = ReadingTime;
        }
        
        public int StationId { get; set; }
        
        public string TemperatureReading { get; set; }
        
        public string ReadingTime { get; set; }
    }
}