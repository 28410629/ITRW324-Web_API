using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ITemperatureReadingOverTimeService
    {
        TemperatureReadingsOverTimeDto FetchAllStationDayTemperatureReadingsOverTime();

        TemperatureReadingsOverTimeDto FetchAllStationWeekTemperatureReadingsOverTime();
        
        TemperatureReadingsOverTimeDto FetchAllStationMonthTemperatureReadingsOverTime();
        TemperatureReadingsOverTimeDto FetchStationDayTemperatureReadingsOverTime(int StationId);
        
        TemperatureReadingsOverTimeDto FetchStationWeekTemperatureReadingsOverTime(int StationId);
        
        TemperatureReadingsOverTimeDto FetchStationMonthTemperatureReadingsOverTime(int StationId);
    }
}