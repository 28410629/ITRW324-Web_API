using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces
{
    public interface IStationSaveReadingService
    {
        void CreateNewReading(ReadingDto reading);
    }
}