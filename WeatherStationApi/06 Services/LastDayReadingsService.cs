using System;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;
using System.Linq;

namespace WeatherStationApi._06_Services
{
    public class LastDayReadingsService: IFetchLastDayReadingsService
    {

        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public LastDaysDto FetchLastDayReadings()
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1))
                .Select(x => new LastDayDto(x.StationId, x.Temperature.ToString(), x.Humidity.ToString(), x.AirPressure.ToString(), x.AmbientLight.ToString() ));

            
            return new LastDaysDto
            {
                LastDayReadings = readings.ToList()
            };
        }
        
        public LastDaysDto FetchLastDayReadingsByStation(int StationId)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-1) && x.StationId==StationId)
                .Select(x => new LastDayDto(x.StationId, x.Temperature.ToString(), x.Humidity.ToString(), x.AirPressure.ToString(), x.AmbientLight.ToString() ));

            
            return new LastDaysDto
            {
                LastDayReadings = readings.ToList()
            };
        }
        
        
    }
}