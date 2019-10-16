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
        
        // get the four day forecast from the reference point of Date.
        public double[] FetchForecast(int StationId, DateTime Date)
        {
            Console.WriteLine("[  OK!  ] Getting forecast for station: " + StationId + " with date: " + Date + ".");
            // query the temperature data from the database.
            var Readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-3) && x.StationId == StationId)
                .GroupBy(x => x.ReadingDateTime.Day)
                .Select(y => new ForecastDto(y.Average(x => x.Temperature), y.Key))
                .ToList();
            double Day1 = 0f, Day2 = 0f, Day3 = 0f;
            try {
                Day1 = Readings[0].Day;
                Console.WriteLine("[  OK!  ] Found day " + Readings[0].ReadingDay + " for readings for " 
                                  + StationId + " on four day forecast.");
            }
            catch (Exception)
            {
                Console.WriteLine("[  ERR  ] Missing last day's readings for " + StationId + " on four day forecast.");
            }
            try {
                Day2 = Readings[1].Day;
                Console.WriteLine("[  OK!  ] Found day " + Readings[1].ReadingDay + " for readings for " 
                                  + StationId + " on four day forecast.");
            }
            catch (Exception) {
                Console.WriteLine("[  ERR  ] Missing yesterday's readings for " + StationId + " on four day forecast.");
            }
            try {
                Day3 = Readings[2].Day;
                Console.WriteLine("[  OK!  ] Found day " + Readings[2].ReadingDay + " for readings for " 
                                  + StationId + " on four day forecast.");
            }
            catch (Exception) {
                Console.WriteLine("[  ERR  ] Missing today's readings for " + StationId + " on four day forecast.");
            }
            // use a weighted moving average of three days to forecast four days.
            double[] results = new double[4];
            double f1 = (Day1 + Day2*2f + Day3*3f)/6f;
            results[0] = f1;
            double f2 = (Day2 + Day3*2f + f1*3f)/6f;
            results[1] = f2;
            double f3 = (Day3 + f1*2f + f2*3f)/6f;
            results[2] = f3;
            double f4 = (f1 + f2*2f + f3*3f)/6f;
            results[3] = f4;
            Console.WriteLine("[  OK!  ] Forecast generated successfully for " + StationId + ".");
            return results;
        }
    }
}