using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class AverageReadingsDto
    {
        public List<AverageReadingDto> AverageReadings { get; set; } = new List<AverageReadingDto>();
    }
}