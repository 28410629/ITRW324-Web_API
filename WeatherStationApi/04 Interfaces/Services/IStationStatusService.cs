using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IStationStatusService
    {
        StationsStatusesDto FetchStationStatus(string StringStationIds, DateTime Date);
    }
}