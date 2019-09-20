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
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddHours(-24) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId, 
                    i.Temperature,
                    i.Humidity,
                    i.AirPressure,
                    i.AmbientLight,
                    i.ReadingDateTime));
            
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
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-7) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId, i.Temperature,i.Humidity,i.AirPressure,i.AmbientLight,i.ReadingDateTime));

            return new StationDetailDays()
            {
                StationDetails = TimeRangeDataProcessing.ProcessWeekReadings(readings.ToList())
            };
        }

        public StationDetailDays FetchStationDetailMonth(int stationID)
        {
            Console.WriteLine("Linq");
            var readings =  _readingsRepository
                .FetchAll()
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-31) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId, i.Temperature,i.Humidity,i.AirPressure,i.AmbientLight,i.ReadingDateTime));
            
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
                .Where(x => x.ReadingDateTime >= DateTime.Now.AddDays(-365) && x.StationId == stationID)
                .Select(i => new StationDetail(
                    i.StationId, i.Temperature,i.Humidity,i.AirPressure,i.AmbientLight,i.ReadingDateTime));

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