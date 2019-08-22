using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class StationsStatusesDto
    {
        public List<StationStatusDto> Readings { get; set; } = new List<StationStatusDto>();
    }
}