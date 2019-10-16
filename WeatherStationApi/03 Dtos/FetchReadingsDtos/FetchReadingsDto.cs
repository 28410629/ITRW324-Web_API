using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class FetchReadingsDto
    {
        public List<FetchReadingDto> Readings { get; set; } = new List<FetchReadingDto>();
    }
}
