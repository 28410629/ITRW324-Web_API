using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    // explicitly states methods for StationsStatusesDto.
    public interface IStationStatusService
    {
        StationsStatusesDto FetchStationStatus(string StringStationIds, DateTime Date);
    }
}
