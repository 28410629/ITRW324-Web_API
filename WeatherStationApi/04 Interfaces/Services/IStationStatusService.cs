using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IStationStatusService
    {
        StationStatusDto FetchStationStatus(int StationId);
    }
}