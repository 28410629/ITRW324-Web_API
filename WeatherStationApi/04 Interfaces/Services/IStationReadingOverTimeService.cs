using WeatherStationApi._03_Dtos;

namespace WeatherStationApi._04_Interfaces.Services
{
    public interface ITemperatureReadingOverTimeService
    {
        StationDetailDays FetchStationDetailDay(int stationID);
        StationDetailDays FetchStationDetailWeek(int stationID);
        StationDetailDays FetchStationDetailMonth(int stationID);
        StationDetailDays FetchStationDetailYear(int stationID);
    }
}