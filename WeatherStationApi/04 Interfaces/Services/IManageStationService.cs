namespace WeatherStationApi._04_Interfaces.Services
{
    public interface IManageStationService
    {
        bool CreateStation(string Province, string City, int StationId, string Nickname);
        bool DeleteStation(int StationId);
        bool EditStation(string Province, string City, int StationId, string Nickname);
    }
}