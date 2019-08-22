using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ITemperatureReadingOverTimeService
    {
        AverageReadingsDto FetchAverageDayAllStationsReadings();
        
        AverageReadingsDto FetchAverageWeekAllStationsReadings();
        
        AverageReadingsDto FetchAverageMonthAllStationsReadings();
    }
}