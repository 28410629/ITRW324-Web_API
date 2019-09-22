using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.CodeAnalysis;
using WeatherStationApi._01_Common.Utilities;
using WeatherStationApi._03_Dtos;
using WeatherStationApi._04_Interfaces.Repositories;
using WeatherStationApi._04_Interfaces.Services;
using WeatherStationApi._05_Repositories;

namespace WeatherStationApi._06_Services
{
    public class TemperatureReadingsOverTimeService : ITemperatureReadingOverTimeService
    {
        private static readonly DataContextFactory _factory = new DataContextFactory();
        private readonly IReadingsRepository _readingsRepository = new ReadingsRepository(_factory);

        public StationDetailDays FetchStationDetailDay(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime.Date == DateTime.Now.Date && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId, 
                    i.Temperature,
                    i.Humidity,
                    i.AirPressure,
                    i.AmbientLight,
                    i.ReadingDateTime)
                );
            
            return new StationDetailDays()
            {
                StationDetails = TimeRangeDataProcessing.ProcessDayReadings(readings.ToList())
            };
        }

        public StationDetailDays FetchStationDetailWeek(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime.Date >= DateTime.Now.Date.AddDays(-7) && x.StationId == stationID)
                .GroupBy(y => y.ReadingDateTime.Date)
                .Select(y => new StationDetailDay(
                    stationID,
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

        public StationDetailDays FetchStationDetailMonth(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime.Date >= DateTime.Now.Date.AddDays(-31) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId,
                    i.Temperature,
                    i.Humidity,
                    i.AirPressure
                    ,i.AmbientLight,
                    i.ReadingDateTime)
                );
            
            return new StationDetailDays()
            {
                StationDetails = TimeRangeDataProcessing.ProcessMonthReadings(readings.ToList())
            };
        }
        
        public StationDetailDays FetchStationDetailYear(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime.Date >= DateTime.Now.Date.AddDays(-365) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId,
                    i.Temperature,
                    i.Humidity,
                    i.AirPressure
                    ,i.AmbientLight,
                    i.ReadingDateTime)
                );

            return new StationDetailDays()
            {
                StationDetails = TimeRangeDataProcessing.ProcessYearReadings(readings.ToList())
            };
        }

        /*public TemperatureReadingsOverTimeDto FetchStationWeekTemperatureReadingsOverTime(int stationID)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == stationID)
                .Select(i => new TemperatureReadingOverTimeDto(
                    i.StationId, i.Temperature.ToString(),i.Humidity.ToString(),i.AirPressure.ToString(),i.AmbientLight.ToString(),i.ReadingDateTime));
            
            /*var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));#1#

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }

        public TemperatureReadingsOverTimeDto FetchStationMonthTemperatureReadingsOverTime(int stationID)
        {
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == stationID)
                .Select(i => new TemperatureReadingOverTimeDto(
                    i.StationId, i.Temperature.ToString(),i.Humidity.ToString(),i.AirPressure.ToString(),i.AmbientLight.ToString(),i.ReadingDateTime));
            
            /*var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == StationId)
                .Select(x => new TemperatureReadingOverTimeDto(x.StationId, x.Temperature.ToString(),x.ReadingDateTime));#1#

            
            return new TemperatureReadingsOverTimeDto
            {
                TemperatureReadingOverTime = readings.ToList()
            };
        }*/
    }
}