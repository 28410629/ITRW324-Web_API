using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    // explicitly states methods for StationDetailDays.
    public interface IStationDetailService
    {
        StationDetailDays FetchStationDetailDay(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailWeek(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailMonth(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailYear(int stationID, DateTime Date);
    }
}
