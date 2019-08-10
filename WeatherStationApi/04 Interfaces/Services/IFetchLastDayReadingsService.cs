using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IFetchLastDayReadingsService
        {
            LastDaysDto FetchLastDayReadings();
            LastDaysDto FetchLastDayReadingsByStation(int StationId);
        }
}