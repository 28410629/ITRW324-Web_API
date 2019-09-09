using System.Collections.Generic;
namespace WeatherStationApi._03_Dtos
{
    public class StationDetailDays
    {
        public List<StationDetailDay> StationDetails { get; set; } = new List<StationDetailDay>();
    }
}