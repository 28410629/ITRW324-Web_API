using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class LastDaysDto
    {
        public List<LastDayDto> LastDayReadings { get; set; } = new List<LastDayDto>();
    }
}