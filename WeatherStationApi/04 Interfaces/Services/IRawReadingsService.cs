using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IRawReadingsService
    {
        RawReadingsDto FetchRawDayAStationReadings(int StationId);
        RawReadingsDto FetchRawWeekAStationReadings(int StationId);
        RawReadingsDto FetchRawMonthAStationReadings(int StationId);
        RawReadingsDto FetchRawYearAStationReadings(int StationId);
    }
}