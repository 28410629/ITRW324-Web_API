using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ITemperatureReadingOverTimeService
    {
        StationDetailDays FetchStationDetailDay(int stationID);
        
        TemperatureReadingsOverTimeDto FetchStationWeekTemperatureReadingsOverTime(int StationId);
        
        TemperatureReadingsOverTimeDto FetchStationMonthTemperatureReadingsOverTime(int StationId);
    }
}