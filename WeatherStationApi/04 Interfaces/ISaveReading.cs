using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces
{
    public interface ISaveReading
    {
        void CreateNewReading(ReadingDto reading);
    }
}