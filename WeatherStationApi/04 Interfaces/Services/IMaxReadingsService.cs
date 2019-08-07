using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IMaxReadingsService
    {
        ReadingsDto FetchMaxDayAllStationsReadings();
        
        ReadingsDto FetchMaxWeekAllStationsReadings();
        
        ReadingsDto FetchMaxMonthAllStationsReadings();
    }
}