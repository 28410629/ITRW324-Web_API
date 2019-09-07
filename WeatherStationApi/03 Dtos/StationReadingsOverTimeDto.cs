using System.Collections.Generic;
namespace WeatherStationApi._03_Dtos
{
    public class TemperatureReadingsOverTimeDto
    {
        public List<TemperatureReadingOverTimeDto> TemperatureReadingOverTime { get; set; } = new List<TemperatureReadingOverTimeDto>();
    }
}