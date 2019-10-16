using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class StationListsDto
    {
        public List<StationListDto> Stations { get; set; } = new List<StationListDto>();
    }
}