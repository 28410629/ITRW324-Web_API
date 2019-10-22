using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces
{
    // explicitly states methods for ReadingDto.
    public interface ISaveReadingService
    {
        void CreateNewReading(ReadingDto reading);
    }
}
