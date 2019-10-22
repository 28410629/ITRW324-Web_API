using System;
using System.Linq;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._02_Models;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class ManageStationService : IManageStationService
    {
        private static DataContextFactory _factory = new DataContextFactory();
        private readonly ILocationsRepository _locationsRepository = new LocationsRepository(_factory);
        private readonly IStationsRepository _stationsRepository = new StationsRepository(_factory);

        // writes a new station reading to the database and commits.
        public bool CreateStation(string Province, string City, int StationId, string Nickname)
        {
            try
            {
                var location = _locationsRepository
                    .FetchAll()
                    .SingleOrDefault(y => y.City == City && y.Province == Province);

                if (location == null)
                {
                    location = new Location()
                    {
                        City = City,
                        Province = Province
                    };
                    _locationsRepository.Add(location);
                    _locationsRepository.Save();
                }
                
                _stationsRepository.Add(new Station()
                {
                    StationId = StationId,
                    NickName = Nickname,
                    LocationId = location.LocationId,
                    Location = location
                });
                _stationsRepository.Save();

                return true; // success
            }
            catch (Exception e)
            {
                LogErrorEmail.SendError(e);
                return false; // failure
            }
        }
        
        public bool EditStation(string Province, string City, int StationId, string Nickname)
        {
            try
            {
                var station = _stationsRepository
                    .FetchAll()
                    .SingleOrDefault(x => x.StationId == StationId);
            
                var location = _locationsRepository
                    .FetchAll()
                    .SingleOrDefault(x => x.City == City && x.Province == Province);
            
                if (location == null)
                {
                    Console.WriteLine("[  ERR  ] Location doesn't exist, creating one.'");
                    location = new Location()
                    {
                        City = City,
                        Province = Province
                    };
                    _locationsRepository.Add(location);
                    _locationsRepository.Save();
                }

                if (station != null)
                {
                    station.NickName = Nickname;
                    station.LocationId = location.LocationId;
                    _stationsRepository.Save();
                }
                else
                {
                    Console.WriteLine("[  ERR  ] Can't edit station due to location data inconsistency.'");
                }
                return true; // success
            }
            catch (Exception e)
            {
                LogErrorEmail.SendError(e);
                return false; // failure
            }
        }
        
        public bool DeleteStation(string Province, string City, int StationId, string Nickname)
        {
            try
            {
                var station = _stationsRepository
                    .FetchAll()
                    .SingleOrDefault(x => x.StationId == StationId);

                if (station != null)
                {
                    _stationsRepository.Remove(station);
                    _stationsRepository.Save();
                }
                else
                {
                    Console.WriteLine("[  ERR  ] Can't delete station due to it not existing.'");
                }
                return true; // success
            }
            catch (Exception e)
            {
                LogErrorEmail.SendError(e);
                return false; // failure
            }
        }
    }
}