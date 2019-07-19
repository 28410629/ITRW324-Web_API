using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class ReadingsDto
    {
        public List<ReadingDto> Readings { get; set; } = new List<ReadingDto>();
    }
}
