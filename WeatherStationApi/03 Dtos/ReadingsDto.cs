using System.Collections.Generic;
using System.Linq;

namespace WeatherStationApi._03_Dtos
{
    public class ReadingsDto
    {
        public IEnumerable<ReadingDto> Readings { get; set; } = Enumerable.Empty<ReadingDto>();
    }
}
