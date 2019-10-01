using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class LocationReadingsDto
    {
        public List<LocationReadingDto> Readings { get; set; } = new List<LocationReadingDto>();
        
        public int Found { get; set; }
    }
}