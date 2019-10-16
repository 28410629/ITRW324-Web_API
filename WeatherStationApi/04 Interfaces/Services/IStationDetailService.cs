using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IStationDetailService
    {
        StationDetailDays FetchStationDetailDay(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailWeek(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailMonth(int stationID, DateTime Date);
        StationDetailDays FetchStationDetailYear(int stationID, DateTime Date);
    }
}