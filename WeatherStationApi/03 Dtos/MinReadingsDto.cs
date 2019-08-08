using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class MinReadingsDto
    {
        public List<MinReadingDto> MinReadings { get; set; } = new List<MinReadingDto>();
    }
}