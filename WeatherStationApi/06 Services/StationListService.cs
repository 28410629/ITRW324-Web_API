using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;
using System.Linq;

namespace WeatherStationApi._06_Services
{
    public class StationListService : IStationListService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IStationsRepository __stationRepository = new StationsRepository(_factory);
        
        public StationListsDto FetchStations()
        {
            var readings =  __stationRepository
                .FetchAll()
                .OrderBy(y => y.StationId)
                .Select(x => new StationListDto(
                    x.StationId,
                    x.UserId,
                    x.LocationId,
                    x.NickName)
                );

            return new StationListsDto
            {
                Stations = readings.ToList()
            };
        }
    }
}