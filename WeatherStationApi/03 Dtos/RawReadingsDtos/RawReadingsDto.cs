using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class RawReadingsDto
    {
        public List<RawReadingDto> Readings { get; set; } = new List<RawReadingDto>();
    }
}