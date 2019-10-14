using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class ForecastService : IForecastService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);



        public ForecastDto FetchForecast(int stationID, DateTime Date)
        {

            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-3) && x.StationId == stationID)
                .GroupBy(x => x.ReadingDateTime.Day)
                .Select(y => y.Average(x => x.Temperature)
                ).ToList();
            

            return null;
        }
    }
}