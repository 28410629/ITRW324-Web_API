using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ITemperatureReadingOverTimeService
    {
        TemperatureReadingOverTimeDto FetchAverageDayAllStationsReadings(int StationId);
        
        TemperatureReadingOverTimeDto FetchAverageWeekAllStationsReadings(int StationId);
        
        TemperatureReadingOverTimeDto FetchAverageMonthAllStationsReadings(int StationId);
    }
}