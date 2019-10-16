using System;
using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IRawReadingsService
    {
        // interface for accessing FetchRawDayAStationReadings from RawReadingsDto.
        RawReadingsDto FetchRawDayAStationReadings(int StationId, DateTime Date);

        // interface for accessing FetchRawWeekAStationReadings from RawReadingsDto.
        RawReadingsDto FetchRawWeekAStationReadings(int StationId, DateTime Date);

        // interface for accessing FetchRawMonthAStationReadings from RawReadingsDto.
        RawReadingsDto FetchRawMonthAStationReadings(int StationId, DateTime Date);

        // interface for accessing FetchRawYearAStationReadings from RawReadingsDto.
        RawReadingsDto FetchRawYearAStationReadings(int StationId, DateTime Date);
    }
}
