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
                .Where(x => x.ReadingDateTime >= Date.AddDays(-4) && x.StationId == StationId)
                .GroupBy(x => x.ReadingDateTime.Day)
                .Select(y => new ForecastDto(y.Average(x => x.Temperature), y.Key))
                .ToList();
            double Day1 = 0f, Day2 = 0f, Day3 = 0f, Day4 = 0f;
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
            try {
                Day4 = Readings[3].Day;
                Console.WriteLine("[  OK!  ] Found day " + Readings[3].ReadingDay + " for readings for " 
                                  + StationId + " on four day forecast.");
            }
            catch (Exception) {
                Console.WriteLine("[  ERR  ] Missing today's readings for " + StationId + " on four day forecast.");
            }
            // use FIT to forecast four days of temperatures.
            double[] Forecasts = new double[8];
            double[] Trend = new double[8];
            double[] FIT = new double[8];
            double[] YData = new double[8] { Day1, Day2, Day3, Day4 ,0 ,0, 0, 0};
            Trend[0] = 0;
            Forecasts[0] = YData[0];
            FIT[0] = Trend[0] + Forecasts[0];
            for (int x = 4; x < 8; x++) {
                for (int i = 1; i <= x; i++) {
                    Forecasts[i] = FIT[i - 1] + 0.2 * (YData[i - 1] - FIT[i - 1]);
                    Trend[i] = Trend[i - 1] + 0.2 * (Forecasts[i] - FIT[i - 1]);
                    FIT[i] = Forecasts[i] + Trend[i];
                }
                YData[x] = FIT[x];
            }
            double[] Results = new double[4] {YData[4], YData[5], YData[6], YData[7]};
            return Results;
        }
    }
}