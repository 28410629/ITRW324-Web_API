using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces
{
    public interface ISaveReadingService
    {
        void CreateNewReading(ReadingDto reading);
    }
}