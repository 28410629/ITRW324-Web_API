using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class MaxReadingsDto
    {
        public List<MaxReadingDto> MaxReadings { get; set; } = new List<MaxReadingDto>();
    }
}