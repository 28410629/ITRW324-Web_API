using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
  // explicitly states methods for FetchReadingsDto.
    public interface IFetchReadingsService
    {
        FetchReadingsDto FetchReadings();
    }
}
