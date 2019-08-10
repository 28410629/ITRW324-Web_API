using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IMinReadingsService
    {
        MinReadingsDto FetchMinDayAllStationsReadings();
        
        MinReadingsDto FetchMinWeekAllStationsReadings();
        
        MinReadingsDto FetchMinMonthAllStationsReadings();

        MinReadingsDto FetchMinDayAStationReadings(int StationId);

        MinReadingsDto FetchMinWeekAStationReadings(int StationId);

        MinReadingsDto FetchMinMonthAStationReadings(int StationId);
    }
}