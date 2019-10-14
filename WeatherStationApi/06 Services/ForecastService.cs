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



        public double[] FetchForecast(int stationID, DateTime Date)
        {

            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= Date.AddDays(-3) && x.StationId == stationID)
                .GroupBy(x => x.ReadingDateTime.Day)
                .Select(y => new ForecastDto(
                        y.Average(x => x.Temperature))
                ).ToList();

            double day1=0f, day2=0f, day3 = 0f;

            try { day1 = readings[0].Day; } catch (Exception e) {}
            try { day2 = readings[1].Day; } catch (Exception e) {}
            try { day3 = readings[2].Day; } catch (Exception e) {}

            double[] results = new double[4];
            double f1 = (day1 + day2*2f + day3*3f)/6f;
            results[0] = f1;
            
            double f2 = (day2 + day3*2f + f1*3f)/6f;
            results[1] = f2;
            
            double f3 = (day3 + f1*2f + f2*3f)/6f;
            results[2] = f3;
            
            double f4 = (f1 + f2*2f + f3*3f)/6f;
            results[3] = f4;
            
            
            
            return results;
        }
    }
}