using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IAverageReadingsService
    {
        AverageReadingsDto FetchAverageDayAllStationsReadings();
        
        AverageReadingsDto FetchAverageWeekAllStationsReadings();
        
        AverageReadingsDto FetchAverageMonthAllStationsReadings();

        AverageReadingsDto FetchAverageDayAStationReadings(int StationId);

        AverageReadingsDto FetchAverageWeekAStationReadings(int StationId);

        AverageReadingsDto FetchAverageMonthAStationReadings(int StationId);
    }
}