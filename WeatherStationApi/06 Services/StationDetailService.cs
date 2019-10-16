using System;
using System.Linq;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class StationDetailService : IStationDetailService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationDetailDays FetchStationDetailDay(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchDayStation(StationId, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month, y.ReadingDateTime.Day, y.ReadingDateTime.Hour})
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    new DateTime(y.Key.Year, y.Key.Month, y.Key.Day, y.Key.Hour, 0, 0))
                ).ToList();

            if (readings.Count() >= 2)
            {
                for (int i = 1; i < readings.Count(); i++)
                {
                    if (readings[i-1].ReadingTime.AddHours(1).CompareTo(readings[i].ReadingTime) != 0)
                    {
                        readings.Insert(i, new StationDetailDay(
                            readings[i].StationId,
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            0.ToString(),
                            readings[i-1].ReadingTime.AddHours(1)));
                        --i;
                    }
                }
            }
            
            return new StationDetailDays()
            {
                StationDetails = readings
            };
        }

        public StationDetailDays FetchStationDetailWeek(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchWeekStation(StationId, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    y.Key)
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }

        public StationDetailDays FetchStationDetailMonth(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchMonthStation(StationId, Date)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    y.Key)
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }
        
        public StationDetailDays FetchStationDetailYear(int StationId, DateTime Date)
        {
            var readings =  _readingsRepository
                .FetchYearStation(StationId, Date)
                .GroupBy(y => new {y.ReadingDateTime.Year, y.ReadingDateTime.Month})
                .Select(y => new StationDetailDay(
                    StationId,
                    y.Average(x => x.Temperature).ToString(),
                    y.Min(x => x.Temperature).ToString(),
                    y.Max(x => x.Temperature).ToString(),
                    y.Average(x => x.Humidity).ToString(),
                    y.Min(x => x.Humidity).ToString(),
                    y.Max(x => x.Humidity).ToString(),
                    y.Average(x => x.AirPressure).ToString(),
                    y.Min(x => x.AirPressure).ToString(),
                    y.Max(x => x.AirPressure).ToString(),
                    y.Average(x => x.AmbientLight).ToString(),
                    y.Min(x => x.AmbientLight).ToString(),
                    y.Max(x => x.AmbientLight).ToString(),
                    new DateTime(y.Key.Year, y.Key.Month, 1))
                );

            return new StationDetailDays()
            {
                StationDetails = readings.ToList()
            };
        }
    }
}