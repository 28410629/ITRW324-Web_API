using System.Collections.Generic;

namespace WeatherStationApi._03_Dtos
{
    public class ForecastsDto
    {
        public List<ForecastDto> ForecastDtos { get; set; } = new List<ForecastDto>();       
    }
}
