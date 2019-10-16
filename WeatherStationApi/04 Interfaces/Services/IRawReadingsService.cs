using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IRawReadingsService
    {
        RawReadingsDto FetchRawDayAStationReadings(int StationId, DateTime Date);
        RawReadingsDto FetchRawWeekAStationReadings(int StationId, DateTime Date);
        RawReadingsDto FetchRawMonthAStationReadings(int StationId, DateTime Date);
        RawReadingsDto FetchRawYearAStationReadings(int StationId, DateTime Date);
    }
}